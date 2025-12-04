using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteRotator : MonoBehaviour
{
    public SoundLibrary soundLib;

    // VARIABLE NUEVA: Esta es la "bandera" de seguridad
    private bool isCollected = false;

    void Update()
    {
        // Rotamos el objeto constantemente
        transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // 1. PASO DE SEGURIDAD:
        // Si ya fue recogido (isCollected es true), detenemos el código aquí mismo.
        // Esto evita que el segundo collider del jugador active el premio otra vez.
        if (isCollected) return;

        if (other.gameObject.CompareTag("Player"))
        {
            // 2. MARCAR COMO RECOGIDO INMEDIATAMENTE
            isCollected = true;

            // 3. Lógica del premio
            Score.bottles += 1;

            // Busca el sonido de forma segura (verifica si existe primero)
            if (FindObjectOfType<SoundLibrary>() != null)
            {
                FindObjectOfType<SoundLibrary>().PlayPickup();
            }

            // Desactivar el objeto
            gameObject.SetActive(false);
        }
    }
}