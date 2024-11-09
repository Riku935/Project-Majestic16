using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class Store : MonoBehaviour
{
    public GameObject storePanel;
    public GameObject interactButton;
    public TextMeshProUGUI moneyText;
    public Sprite[] helmets;
    private int money = 0;
    private bool jugadorCerca = false;
    public SpriteRenderer playerHelmet;
    private Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        moneyText.text = money.ToString();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        interactButton.SetActive(true);
        jugadorCerca=true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        interactButton.SetActive(false);
        storePanel.SetActive(false);
        jugadorCerca=false;
    }
    private void Update()
    {
        if (jugadorCerca && Input.GetKeyDown(KeyCode.E) )
        {
            storePanel.SetActive(!storePanel.activeSelf);
        }

    }
    public void DarDinero(int cantidad)
    {
        money += cantidad;
        moneyText.text = money.ToString();
    }
    public void Comprar(int id)
    {

        if (money >= 15 && id != 6)
        {
            playerHelmet.sprite = helmets[id];
            money -= 15; 
            moneyText.text = money.ToString();
        }
        else if (id == 6 && player.vida < player.maxVida && money >= 5) 
        {
            player.vida = Mathf.Min(player.vida + 10, player.maxVida); 
            money -= 5;
            moneyText.text = money.ToString();
            player.healthText.text = player.vida.ToString();
        }
    }
}
