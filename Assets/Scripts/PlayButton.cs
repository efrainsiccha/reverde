using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OpenOptions()
    {
        // Carga la escena por su nombre exacto (como se ve en tu carpeta)
        SceneManager.LoadScene("Options");
    }

    public void StarMenu()
    {
        // Carga la escena por su nombre exacto (como se ve en tu carpeta)
        SceneManager.LoadScene("StartMenu");
    }

    public void salirBoton()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    
    }

}
