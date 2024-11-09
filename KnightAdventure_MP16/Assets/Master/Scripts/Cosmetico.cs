using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cosmetico : MonoBehaviour
{
    public string nombre;
    public int id;
    private Store store;

    private void Start()
    {
        store = FindObjectOfType<Store>();
    }
    public void CascoElegido()
    {
        store.Comprar(id);
    }
}
