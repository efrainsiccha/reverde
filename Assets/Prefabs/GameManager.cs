using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Quitamos 'hit' y 'updated' porque causan conflictos. 
    // Controlaremos la muerte única desde la función EndGame directamente.

    public static int lives = 4;

    // Update is called once per frame
    void Update()
    {

    }

    // Esta función ahora recibe el daño directamente
    public void EndGame()
    {
        // 1. Restamos la vida inmediatamente
        lives--;

        Debug.Log("Vida restada. Vidas restantes: " + lives);

        // 2. Comprobamos si aún le quedan vidas PARA JUGAR
        // Si tiene más de 0 (1, 2, 3...), reiniciamos nivel.
        if (lives > 0)
        {
            Invoke("Restart", 2f);
        }
        // Si tiene 0 o menos, se acabó el juego.
        else
        {
            Invoke("GameOver", 2f);
        }
    }

    public void Restart()
    {
        Score.bottles = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        // Reseteamos las vidas para la próxima vez que juegue desde el menú
        lives = 4;
        // Asegúrate de que el índice 0 es tu Menú Principal en Build Settings
        SceneManager.LoadScene(0);
    }
}