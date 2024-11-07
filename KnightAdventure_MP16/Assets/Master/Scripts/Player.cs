using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Entidad
{
    public List<Recurso> inventario = new List<Recurso>();
    public int dinero;

    public void RecolectarRecurso(Recurso recurso)
    {
        inventario.Add(recurso);
    }

    public void VenderRecurso(Recurso recurso, int precio)
    {
        if (inventario.Contains(recurso))
        {
            dinero += precio;
            inventario.Remove(recurso);
        }
    }

    public void ComprarCosmetico(Cosmetico cosmetico)
    {
        if (dinero >= cosmetico.precio)
        {
            dinero -= cosmetico.precio;
            cosmetico.Equipar(this);
        }
    }

    public void PlantarSemilla(Recurso semilla)
    {
        if (semilla.tipo == Recurso.TipoRecurso.Semilla)
        {
            Instantiate(semilla.cultivoPrefab, transform.position, Quaternion.identity);
            inventario.Remove(semilla);
        }
    }
}
