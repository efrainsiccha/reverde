using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleType3 : MonoBehaviour
{
    public void reiniciarNivel1()
    {
        SceneManager.LoadScene("Level1");
    }
    public void reiniciarNivel2()
    {
        SceneManager.LoadScene("Level2");
    }
    public void reiniciarNivel3()
    {
        SceneManager.LoadScene("Level3");
    }
    public void reiniciarNivel4()
    {
        SceneManager.LoadScene("Level4");
    }
    public void reiniciarNivel5()
    {
        SceneManager.LoadScene("Level5");
    }

    // Agrega esta variable al principio de tu clase si quieres poder cambiar el número desde Unity
    public int siguienteNivelADesbloquear = 4;

    public void selectorniveles()
    {
        // 1. ELIMINA O COMENTA ESTA LÍNEA (Esta es la que da error):
        // ControladorDeNiveles.instancia.AumentarNiveles();

        // 2. AGREGA ESTO: Guardamos directamente usando PlayerPrefs
        // Verificamos si el nivel que queremos desbloquear es mayor al que ya tenemos
        if (siguienteNivelADesbloquear > PlayerPrefs.GetInt("nivelesDesbloqueados", 1))
        {
            PlayerPrefs.SetInt("nivelesDesbloqueados", siguienteNivelADesbloquear);
            PlayerPrefs.Save(); // Aseguramos que se guarde
        }

        // 3. Cargamos el menú
        SceneManager.LoadScene("SelectorNiveles");
    }

}
