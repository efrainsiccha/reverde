using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class PlayerSettings : MonoBehaviour
{
    [Header("Sliders")]
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    [Header("Audio")]
    [SerializeField] private AudioMixer myMixer;

    void Start()
    {
        // --- CARGA DE MÚSICA ---
        if (PlayerPrefs.HasKey("MusicVol"))
        {
            float vol = PlayerPrefs.GetFloat("MusicVol");
            musicSlider.value = vol;
        }
        else
        {
            musicSlider.value = 1; // Valor por defecto
        }
        // IMPORTANTE: Llamamos a la función para aplicar el volumen al Mixer
        SetMusicVolume();


        // --- CARGA DE EFECTOS (SFX) ---
        if (PlayerPrefs.HasKey("SFXVol"))
        {
            float vol = PlayerPrefs.GetFloat("SFXVol");
            sfxSlider.value = vol;
        }
        else
        {
            sfxSlider.value = 1;
        }
        // IMPORTANTE: Aplicamos el volumen al Mixer
        SetSFXVolume();
    }

    public void SetMusicVolume()
    {
        float volumen = musicSlider.value;

        // PROTECCIÓN: Si el volumen es 0, lo hacemos 0.0001 para evitar -Infinito
        // Esto evita errores matemáticos graves
        if (volumen <= 0.0001f) volumen = 0.0001f;

        myMixer.SetFloat("MusicVolume", Mathf.Log10(volumen) * 20);

        // Guardamos el valor real del slider, no el modificado
        PlayerPrefs.SetFloat("MusicVol", musicSlider.value);
    }

    public void SetSFXVolume()
    {
        float volumen = sfxSlider.value;

        // PROTECCIÓN
        if (volumen <= 0.0001f) volumen = 0.0001f;

        myMixer.SetFloat("SFXVolume", Mathf.Log10(volumen) * 20);

        PlayerPrefs.SetFloat("SFXVol", sfxSlider.value);
    }
}