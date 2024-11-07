using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemigo")
        {
            Enemigo enemigo = collision.GetComponent<Enemigo>();
            enemigo.TakeDamage(10);
        }
    }
}
