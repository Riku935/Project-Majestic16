using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Dictionary<string, int> recursos = new Dictionary<string, int>
    {
        { "CarrotSeed", 0 },
        { "OnionSeed", 0 },
        {"Carrot",0},
        {"Onion",0}
    };

    // Evento para notificar a la UI cuando se recoja un recurso
    public event Action<string, int> OnRecursoActualizado;

    public void AddRecurso(string recursoNombre)
    {
        if (recursos.ContainsKey(recursoNombre))
        {
            recursos[recursoNombre]++;
            Debug.Log($"Recurso agregado: {recursoNombre}, cantidad total: {recursos[recursoNombre]}");
            OnRecursoActualizado?.Invoke(recursoNombre, recursos[recursoNombre]);
        }
    }
    public int GetCantidadRecurso(string recursoNombre)
    {
        if (recursos.ContainsKey(recursoNombre))
        {
            return recursos[recursoNombre];
        }
        return 0;
    }
    public void RestarRecurso(string nombreRecurso, int cantidad)
    {
        if (recursos.ContainsKey(nombreRecurso))
        {
            recursos[nombreRecurso] -= cantidad;
            if (recursos[nombreRecurso] <= 0)
            {
                recursos[nombreRecurso] = 0;
            }
        }
    }
}
