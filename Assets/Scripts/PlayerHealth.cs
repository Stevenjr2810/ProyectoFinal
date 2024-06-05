using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public Text healthText; // Referencia al componente de texto que muestra la salud

    void Awake()
    {
        currentHealth = maxHealth;
        UpdateHealthText();
        InvokeRepeating("ReduceHealthOverTime", 10f, 10f); // Reduce la salud cada 30 segundos
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
        UpdateHealthText(); // Actualiza el texto de salud
    }

    private void ReduceHealthOverTime()
    {
        TakeDamage(20); // Reduce 20 de vida cada 30 segundos
    }

    private void Die()
    {
        // Aquí puedes añadir la lógica de lo que sucede cuando el jugador muere
        Debug.Log(gameObject.name + " ha muerto.");
    }

    private void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + currentHealth;
        }
    }

    public int GetHealth()
    {
        return currentHealth;
    }
}