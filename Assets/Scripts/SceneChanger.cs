using UnityEngine;
using UnityEngine.SceneManagement; // Aseg�rate de tener esta l�nea

public class SceneChanger : MonoBehaviour
{
    // M�todo que se llamar� al presionar el bot�n
    public void StartGame()
    {
        SceneManager.LoadScene("Select Player"); // Cambia "GameScene" por el nombre de tu escena
    }
}