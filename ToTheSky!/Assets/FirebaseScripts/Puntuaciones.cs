using Firebase;
using Firebase.Database;
using Firebase.Auth;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections.Generic;

public class Puntuaciones : MonoBehaviour
{
    private DatabaseReference dbRef;
    private FirebaseAuth auth;

    private void Awake()
    {
        auth = FirebaseAuth.DefaultInstance;
        dbRef = FirebaseDatabase.DefaultInstance.RootReference;
    }

    // -----------------------------
    // ACTUALIZAR SCORE SOLO SI ES MAYOR
    // -----------------------------
    public async void UpdateScore(int newScore)
    {
        if (auth.CurrentUser == null)
        {
            Debug.LogError("No hay usuario autenticado");
            return;
        }

        string uid = auth.CurrentUser.UserId;
        DatabaseReference scoreRef = dbRef.Child("users").Child(uid).Child("score");

        // Obtener score actual
        var dataSnapshot = await scoreRef.GetValueAsync();

        int currentScore = 0;
        if (dataSnapshot.Exists)
            currentScore = int.Parse(dataSnapshot.Value.ToString());

        Debug.Log($"Score actual: {currentScore}, nuevo: {newScore}");

        // Solo actualizar si es mayor
        if (newScore > currentScore)
        {
            await scoreRef.SetValueAsync(newScore);
            Debug.Log("Score actualizado correctamente en Firebase.");
        }
        else
        {
            Debug.Log("El nuevo score no es mayor, no se actualiza.");
        }
    }


    // -----------------------------
    // OBTENER TOP 10 SCORES
    // -----------------------------
    public async void GetTopScores()
    {
        // Ordenar por "score" descendente, Firebase no permite descendente directo,
        // así que obtenemos todo y luego lo ordenamos en Unity.
        var snapshot = await dbRef.Child("users").GetValueAsync();

        if (!snapshot.Exists)
        {
            Debug.LogError("No hay usuarios en la base de datos.");
            return;
        }

        List<UserScore> users = new List<UserScore>();

        foreach (var child in snapshot.Children)
        {
            string username = child.Child("username").Value != null ?
                child.Child("username").Value.ToString() : "SinNombre";

            int score = 0;
            if (child.Child("score").Value != null)
                int.TryParse(child.Child("score").Value.ToString(), out score);

            users.Add(new UserScore { username = username, score = score });
        }

        // Ordenar descendente
        users.Sort((a, b) => b.score.CompareTo(a.score));

        // Tomar máximo 10
        int count = Mathf.Min(10, users.Count);

        // Construir tabla
        string tabla = "Top       Usuario        Puntaje\n";
        for (int i = 0; i < count; i++)
        {
            tabla += $"{i + 1}.        {users[i].username,-12} {users[i].score}\n";
        }

        Tabla.Instance.ActualizarTabla(tabla);
        Debug.Log(tabla);
    }
}


// Clase auxiliar para el ranking
[System.Serializable]
public class UserScore
{
    public string username;
    public int score;
}
