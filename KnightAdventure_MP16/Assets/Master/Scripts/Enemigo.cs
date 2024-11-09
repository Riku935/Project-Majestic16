using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemigo : Entidad
{
    public Recurso recursoDrop;
    private Player player;
    private float attackDelay = 0;
    public enum TipoEnemigo {Orco,Llama,Slime}
    public TipoEnemigo enemigoActual = TipoEnemigo.Orco;
    private void Start()
    {
        player = FindObjectOfType<Player>();
        if(enemigoActual == TipoEnemigo.Orco)
        {
            MovimientoEnemigo enemMov = GetComponent<MovimientoEnemigo>();
            enemMov.objetivo = player.transform;
        }
    }
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
        if(jugador.vida <= 0)
        {
            SceneManager.LoadScene(1);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(enemigoActual == TipoEnemigo.Llama && collision.gameObject.CompareTag("Player"))
        {
            attackDelay -= Time.deltaTime;
            if(attackDelay <= 0)
            {
                Player player = FindObjectOfType<Player>();
                if (player != null)
                {
                    Atacar(player);
                    attackDelay = 1.2f;
                }
            }
        }
    }
}
