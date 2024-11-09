
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Entidad : MonoBehaviour
{
    public float vida;
    public float maxVida;
    public Image healthBar;
    public TextMeshProUGUI healthText;

    private void Start()
    {
        vida = maxVida;
    }
    public virtual void TakeDamage(float cantidad)
    {
        vida -= cantidad;
        if (healthBar != null && healthText != null)
        {
            healthBar.fillAmount = vida / 50;
            healthText.text = vida.ToString();
        }
        if (vida <= 0)
        {
            Morir();
        }
    }

    protected virtual void Morir()
    {
        Destroy(gameObject);
    }

}
