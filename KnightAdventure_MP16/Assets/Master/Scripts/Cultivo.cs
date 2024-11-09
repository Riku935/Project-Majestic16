using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cultivo : MonoBehaviour
{
    public enum TipoCultivo { Carrot, Onion }
    public TipoCultivo tipoCultivo; // Selección desde el inspector
    public SpriteRenderer sprCarrot;
    public SpriteRenderer sprOnion;
    public GameObject collectIcon;
    public string nombreCosecha;
    public int growingTime;
    private bool canRecolect = false;
    private bool canPlant = true;

    public Sprite[] sprCarrot1;

    private bool cercaDelJugador = false;
    private Inventory inventario;
    private UIController uiController;

    private void Start()
    {
        inventario = FindObjectOfType<Inventory>();
        uiController = FindObjectOfType<UIController>();
        sprCarrot.enabled = false;
        sprOnion.enabled = false;
    }

    private void Update()
    {
        if (cercaDelJugador && Input.GetKeyDown(KeyCode.E) && !canRecolect && canPlant)
        {
            Plantar();
        }
        if (cercaDelJugador && Input.GetKeyDown(KeyCode.E) && !canPlant && canRecolect)
        {
            Recolectar();
        }
    }

    private void Plantar()
    {
        if (tipoCultivo == TipoCultivo.Carrot && inventario.GetCantidadRecurso("CarrotSeed") > 0)
        {
            inventario.RestarRecurso("CarrotSeed", 1);
            uiController.ActualizarUI("CarrotSeed", inventario.GetCantidadRecurso("CarrotSeed"));
            sprCarrot.enabled = true;
            canPlant = false;
            StartCoroutine(Creciendo());
        }
        else if (tipoCultivo == TipoCultivo.Onion && inventario.GetCantidadRecurso("OnionSeed") > 0)
        {
            inventario.RestarRecurso("OnionSeed", 1);
            uiController.ActualizarUI("OnionSeed", inventario.GetCantidadRecurso("OnionSeed"));
            sprOnion.enabled = true;
            canPlant = false;
            StartCoroutine(Creciendo());
        }
        else
        {

        }
    }
    private void Recolectar()
    {
        if (canRecolect == true)
        {
            sprCarrot.enabled = false;
            Inventory inventory = FindObjectOfType<Inventory>();
            if (inventory != null)
            {
                inventory.AddRecurso(nombreCosecha);
            }
            canPlant = true;
            canRecolect = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            cercaDelJugador = true;
            collectIcon.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            cercaDelJugador = false;
            collectIcon.SetActive(false);
        }
    }
    private IEnumerator Creciendo()
    {
        yield return new WaitForSeconds(growingTime);
        sprCarrot.sprite = sprCarrot1[0];
        yield return new WaitForSeconds(growingTime);
        sprCarrot.sprite = sprCarrot1[1];
        canRecolect = true;
    }
}
