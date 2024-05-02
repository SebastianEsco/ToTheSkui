using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MejorasAEdificios : MonoBehaviour
{
    [Header("Index: 0-Iglesia, 1-Energía, 2-Lava")]
    public List<float> bonus = new List<float>();

    public void MejorarEdificio(int index, float cantidadAAumentar)
    {
        bonus[index] += cantidadAAumentar;
    }
}
