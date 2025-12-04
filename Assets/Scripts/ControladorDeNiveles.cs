using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class ControladorDeNiveles : MonoBehaviour
{
    public static ControladorDeNiveles instancia;
    public Button[] botonesNiveles;
    public int desbloquearNiveles;

    // (field) static ControladorNiveles ControladorNiveles.instancia

    private void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
        }
    }

    void Start()
    {
        if (botonesNiveles.Length > 0)
        {
            for (int i = 0; i < botonesNiveles.Length; i++)
            {
                botonesNiveles[i].interactable = false;
            }

            for (int i = 0; i < PlayerPrefs.GetInt("nivelesDesbloqueados", 1); i++)
            {
                botonesNiveles[i].interactable = true;
            }
        }
    }

    public void AumentarNiveles()
    {
        if (desbloquearNiveles > PlayerPrefs.GetInt("nivelesDesbloqueados", 1))
        {
            PlayerPrefs.SetInt("nivelesDesbloqueados", desbloquearNiveles);
        }
    }
}


