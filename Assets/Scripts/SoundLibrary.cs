using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundLibrary : MonoBehaviour
{
    // Al ser publicas, confiamos en que las asignaste en el Inspector (como ya hiciste)
    public AudioSource pickUp;
    public AudioSource explosion;

    // NO NECESITAS EL VOID START
    // Borra la función Start completa. 
    // Unity ya sabe quiénes son porque los arrastraste en la ventanita.

    public void PlayPickup()
    {
        pickUp.Play();
    }

    public void PlayExplosion()
    {
        explosion.Play();
    }
}