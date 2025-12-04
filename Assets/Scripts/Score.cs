using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    public static int bottles = 0;

    public Text scoreText;
    // Update is called once per frame

    // AGREGA ESTO:
    // Start se ejecuta cada vez que se carga la escena
    void Start()
    {
        bottles = 0; // Reiniciamos el contador a 0 al iniciar el nivel
        ActualizarTexto(); // Opcional: actualiza el texto inmediatamente
    }

    void Update()
    {
        scoreText.text = "Botellas: " + bottles.ToString() + "/5";
    }

    void ActualizarTexto()
    {
        scoreText.text = "Botellas: " + bottles.ToString() + "/5";
    }
}
