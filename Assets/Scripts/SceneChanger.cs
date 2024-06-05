using UnityEngine;
using UnityEngine.SceneManagement; // Asegúrate de tener esta línea

public class SceneChanger : MonoBehaviour
{
    // Método que se llamará al presionar el botón
    public void StartGame()
    {
        SceneManager.LoadScene("Select Player"); // Cambia "GameScene" por el nombre de tu escena
    }
}