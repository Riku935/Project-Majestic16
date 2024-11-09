using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cultivo;

public class Cosecha : MonoBehaviour
{
    private Inventory inventario;
    private UIController uiController;
    private Store store;
    public enum TipoCosecha { Carrot, Onion }
    public TipoCosecha tipoCosecha; // Selección desde el inspector
    void Start()
    {
        inventario = FindObjectOfType<Inventory>();
        uiController = FindObjectOfType<UIController>();
        store = FindObjectOfType<Store>();
    }
    public void Vender()
    {
        if (tipoCosecha == TipoCosecha.Carrot && inventario.GetCantidadRecurso("Carrot") > 0)
        {
            inventario.RestarRecurso("Carrot", 1);
            uiController.ActualizarUI("Carrot", inventario.GetCantidadRecurso("Carrot"));
            store.DarDinero(1);
        }
        if (tipoCosecha == TipoCosecha.Onion && inventario.GetCantidadRecurso("Onion") > 0)
        {
            inventario.RestarRecurso("Onion", 1);
            uiController.ActualizarUI("Onion", inventario.GetCantidadRecurso("Onion"));
            store.DarDinero(2);
        }
    }
}
