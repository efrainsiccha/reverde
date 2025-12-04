using UnityEngine;
using UnityEngine.Audio;

public class VolumeLoader : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer; // Arrastra aquí tu MainMixer

    void Start()
    {
        // --- CARGAR MÚSICA ---
        if (PlayerPrefs.HasKey("MusicVol"))
        {
            float musicVol = PlayerPrefs.GetFloat("MusicVol");
            // Protección contra logaritmo de 0
            if (musicVol <= 0.0001f) musicVol = 0.0001f;

            myMixer.SetFloat("MusicVolume", Mathf.Log10(musicVol) * 20);
        }

        // --- CARGAR EFECTOS (SFX) ---
        if (PlayerPrefs.HasKey("SFXVol"))
        {
            float sfxVol = PlayerPrefs.GetFloat("SFXVol");
            // Protección contra logaritmo de 0
            if (sfxVol <= 0.0001f) sfxVol = 0.0001f;

            myMixer.SetFloat("SFXVolume", Mathf.Log10(sfxVol) * 20);
        }
    }
}