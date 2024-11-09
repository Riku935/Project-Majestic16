using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    public Inventory inventory;
    public TextMeshProUGUI seedType1Text;
    public TextMeshProUGUI seedType2Text;
    public TextMeshProUGUI carrotText;
    public TextMeshProUGUI onionText;

    private void Start()
    {
        if (inventory != null)
        {
            inventory.OnRecursoActualizado += ActualizarUI;
            // Inicializa la UI con los valores actuales del inventario
            ActualizarUI("CarrotSeed", inventory.GetCantidadRecurso("CarrotSeed"));
            ActualizarUI("OnionSeed", inventory.GetCantidadRecurso("OnionSeed"));
            ActualizarUI("Onion", inventory.GetCantidadRecurso("Onion"));
            ActualizarUI("Carrot", inventory.GetCantidadRecurso("Carrot"));
        }
    }

    public void ActualizarUI(string recursoNombre, int cantidad)
    {
        if (recursoNombre == "CarrotSeed")
        {
            seedType1Text.text = cantidad.ToString();
        }
        else if (recursoNombre == "OnionSeed")
        {
            seedType2Text.text = cantidad.ToString();
        }
        else if (recursoNombre == "Onion")
        {
            onionText.text = cantidad.ToString();
        }
        else if (recursoNombre == "Carrot")
        {
            carrotText.text = cantidad.ToString();
        }
    }
}
