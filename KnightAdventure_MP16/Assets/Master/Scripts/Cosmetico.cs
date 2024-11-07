using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cosmetico : MonoBehaviour
{
    public string nombre;
    public int precio;
    public Sprite apariencia;

    public void Equipar(Player jugador)
    {
        // Cambia la apariencia del jugador
        SpriteRenderer renderer = jugador.GetComponent<SpriteRenderer>();
        if (renderer != null)
        {
            renderer.sprite = apariencia;
        }
    }
}
