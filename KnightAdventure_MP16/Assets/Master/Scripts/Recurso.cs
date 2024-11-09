using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recurso : MonoBehaviour
{
    public string nombreRecurso;
    public int cantidad = 1;
    private bool jugadorCerca = false;
    public GameObject collectIcon;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = true;
            collectIcon.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = false;
            collectIcon.SetActive(false);
        }
    }

    private void Update()
    {
        if (jugadorCerca && Input.GetKeyDown(KeyCode.E))
        {
            Inventory inventory = FindObjectOfType<Inventory>();
            if (inventory != null)
            {
                inventory.AddRecurso(nombreRecurso);
                Destroy(gameObject);
            }
        }
    }
}
