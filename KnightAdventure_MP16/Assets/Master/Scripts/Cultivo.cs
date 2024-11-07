using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cultivo : MonoBehaviour
{
    public enum Estado { Sembrado, Creciendo, ListoParaCosechar }
    public Estado estadoActual = Estado.Sembrado;
    public float tiempoDeCrecimiento = 5f;
    private float tiempoActual = 0f;

    public Recurso recursoCosecha;

    private void Update()
    {
        if (estadoActual == Estado.Creciendo)
        {
            tiempoActual += Time.deltaTime;
            if (tiempoActual >= tiempoDeCrecimiento)
            {
                estadoActual = Estado.ListoParaCosechar;
            }
        }
    }

    public Recurso Cosechar()
    {
        if (estadoActual == Estado.ListoParaCosechar)
        {
            Destroy(gameObject);
            return recursoCosecha;
        }
        return null;
    }
}
