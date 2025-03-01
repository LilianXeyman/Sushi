using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonSonido : MonoBehaviour
{
    public AudioSource audioSource; // Referencia al AudioSource
    public AudioClip clickSound; // Clip de sonido

    void Start()
    {
        // Pre-carga el sonido si est� asignado
        if (audioSource != null && clickSound != null)
        {
            audioSource.clip = clickSound;
            audioSource.Play();
            audioSource.Stop();
        }
    }

    public void PlayButtonSound()
    {
        if (audioSource != null && clickSound != null)
        {
            audioSource.PlayOneShot(clickSound); // Reproduce el sonido de inmediato
        }
        else
        {
            Debug.LogError("AudioSource o ClickSound no est�n asignados en el Inspector.");
        }
    }
}
