using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Asegúrate de importar este espacio de nombres

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public Text healthText; // Referencia al componente de texto que muestra la salud

    void Awake()
    {
        currentHealth = maxHealth;
        UpdateHealthText();
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

    private void Die()
    {
        // Aquí puedes añadir la lógica de lo que sucede cuando el enemigo muere
        Debug.Log(gameObject.name + " ha muerto.");
        LoadVictoryScene(); // Llamar a la función para cargar la nueva escena
    }

    private void LoadVictoryScene()
    {
        // Cargar la nueva escena cuando el enemigo muere
        SceneManager.LoadScene("VictoryScee"); // Asegúrate de que el nombre coincida con el de tu nueva escena
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
