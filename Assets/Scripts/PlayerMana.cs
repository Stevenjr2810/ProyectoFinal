using UnityEngine;
using UnityEngine.UI;

public class PlayerMana : MonoBehaviour
{
    public int maxMana = 100;
    private int currentMana;

    public Text manaText; // Referencia al componente de texto que muestra el maná

    void Awake()
    {
        currentMana = maxMana;
        UpdateManaText();
    }

    public void UseMana(int amount)
    {
        currentMana -= amount;
        if (currentMana < 0)
        {
            currentMana = 0;
        }
        UpdateManaText(); // Actualiza el texto de maná
    }

    private void UpdateManaText()
    {
        if (manaText != null)
        {
            manaText.text = "Mana: " + currentMana;
        }
    }

    public int GetMana()
    {
        return currentMana;
    }
}