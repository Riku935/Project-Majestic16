using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recurso : MonoBehaviour
{
    public enum TipoRecurso { Semilla, Comida, Material }
    public TipoRecurso tipo;
    public int cantidad;

    // Prefab para el cultivo, �til si es un recurso de tipo Semilla
    public GameObject cultivoPrefab;
}
