using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovimientoEnemigo : MonoBehaviour
{
    public float velocidad = 2f;
    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 direccionMovimiento;
    public Transform objetivo;
    public bool persiguiendoJugador = false;
    public float rangoDeteccion = 5f;  
    public LayerMask capaJugador;
    private bool canAttack = true;
    private Enemigo enemigoScript;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        enemigoScript = GetComponent<Enemigo>();
        GenerarDireccionAleatoria();
    }

    private void Update()
    {
        if (persiguiendoJugador && objetivo != null)
        {
            Vector2 direccionHaciaJugador = (objetivo.position - transform.position).normalized;
            rb.velocity = direccionHaciaJugador * velocidad;
            DetectarJugador();
        }
        else
        {
            rb.velocity = direccionMovimiento * velocidad;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemigo") || collision.gameObject.CompareTag("Pared") || collision.gameObject.CompareTag("Limits") || collision.gameObject.CompareTag("Player"))
        {
            AjustarDireccionAlChocar(collision);
        }
    }
    private void DetectarJugador()
    {
        float distanciaAlJugador = Vector2.Distance(transform.position, objetivo.position);

        if (distanciaAlJugador <= rangoDeteccion && canAttack)
        {
            StartCoroutine(Ataque());    
        }
    }

    private IEnumerator Ataque()
    {
        canAttack = false;
        anim.SetTrigger("Attack");
        Player player = objetivo.GetComponent<Player>();
        if (player != null)
        {
            enemigoScript.Atacar(player);  
        }
        yield return new WaitForSeconds(1.5f);
        canAttack = true;
    }
    private void GenerarDireccionAleatoria()
    {
        float angulo = Random.Range(0, 2 * Mathf.PI);
        direccionMovimiento = new Vector2(Mathf.Cos(angulo), Mathf.Sin(angulo)).normalized;
    }

    private void AjustarDireccionAlChocar(Collision2D collision)
    {
        Vector2 normalColision = collision.contacts[0].normal;
        direccionMovimiento = Vector2.Reflect(direccionMovimiento, normalColision).normalized;
        transform.position += (Vector3)normalColision * 0.1f; 
    }
}
