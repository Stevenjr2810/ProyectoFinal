using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Método para cambiar de escena. Recibe el nombre de la escena como parámetro.
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Método para salir del juego.
    public void ExitGame()
    {
        // Si estamos en el editor de Unity, usamos el siguiente código para detener la ejecución del juego.
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Si estamos en una build del juego, cerramos la aplicación.
        Application.Quit();
#endif
    }
}
