using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : Entidad
{
    public Recurso recursoDrop;

    protected override void Morir()
    {
        base.Morir();
        if (recursoDrop != null)
        {
            Instantiate(recursoDrop, transform.position, Quaternion.identity);
        }
    }

    public void Atacar(Player jugador)
    {
        jugador.TakeDamage(10); 
    }
}
