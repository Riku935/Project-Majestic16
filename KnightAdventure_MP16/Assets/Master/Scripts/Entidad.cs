using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entidad : MonoBehaviour
{
    public float vida;

    public virtual void TakeDamage(float cantidad)
    {
        vida -= cantidad;
        if (vida <= 0)
        {
            Morir();
        }
    }

    protected virtual void Morir()
    {
        Destroy(gameObject);
    }

}
