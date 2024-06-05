using System.Collections;
using UnityEngine;
using Fungus;

public class DiceManager : MonoBehaviour
{
    public Camera mainCamera;
    public Camera diceCamera;
    public DiceController diceController;
    public Flowchart flowchart;
    public GameObject resultDisplayObject; // GameObject a activar/desactivar

    public void RollDice(int probability)
    {
        StartCoroutine(RollDiceCoroutine(probability));
    }

    private IEnumerator RollDiceCoroutine(int probability)
    {
        Debug.Log("Iniciando RollDiceCoroutine");

        

        // Activa el objeto de resultado
        resultDisplayObject.SetActive(true);
        Debug.Log("Objeto de resultado activado");

        // Cambia a la cámara del dado
        mainCamera.enabled = false;
        diceCamera.enabled = true;
        Debug.Log("Cámaras cambiadas");

        // Lanza el dado
        //diceController.PrepararDado();
        //Debug.Log("Dado preparado");

        // Espera 3 segundos para ver el resultado
        yield return new WaitForSeconds(7);
        Debug.Log("Espera de 3 segundos completada");

        // Desactiva el objeto de resultado
        resultDisplayObject.SetActive(false);
        Debug.Log("Objeto de resultado desactivado");

        // Cambia de nuevo a la cámara principal
        diceCamera.enabled = false;
        mainCamera.enabled = true;
        Debug.Log("Cámaras cambiadas de vuelta");

        // Verifica el resultado del dado
        int resultadoDado = diceController.valorDado;
        Debug.Log("Resultado del dado: " + resultadoDado);

        // Verifica si el resultado es mayor o igual a la probabilidad
        if (resultadoDado >= probability)
        {
            flowchart.ExecuteBlock("SuccessBlock"); // Bloque en Fungus para el éxito
            Debug.Log("Ejecutando bloque de éxito");
        }
        else
        {
            flowchart.ExecuteBlock("FailureBlock"); // Bloque en Fungus para el fallo
            Debug.Log("Ejecutando bloque de fallo");
        }

        Debug.Log("Fin de RollDiceCoroutine");
    }


}

