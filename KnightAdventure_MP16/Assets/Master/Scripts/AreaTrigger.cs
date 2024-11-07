using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaTrigger : MonoBehaviour
{
    public string etiquetaObjetivo = "Player";  
    public MovimientoEnemigo[] enemigos;        

    private void Start()
    {
        enemigos = FindObjectsOfType<MovimientoEnemigo>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(etiquetaObjetivo))
        {
            foreach (var enemigo in enemigos)
            {
                enemigo.persiguiendoJugador = true; 
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(etiquetaObjetivo))
        {
            foreach (var enemigo in enemigos)
            {
                enemigo.persiguiendoJugador = false;
            }
        }
    }
}
