using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sonido : MonoBehaviour
{
    [SerializeField]
    float valueVolume;
    [SerializeField]
    Slider slideVolume;
    [SerializeField]
    Image imageMuteO;

    void Start()
    {
        if (slideVolume == null)
        {
            slideVolume = FindObjectOfType<Slider>(); // Busca un Slider en la escena
            Debug.LogWarning("slideVolume no estaba asignado, se ha buscado automáticamente.");
        }

        if (imageMuteO == null)
        {
            imageMuteO = FindObjectOfType<Image>(); // Busca una imagen en la escena
            Debug.LogWarning("imageMuteO no estaba asignado, se ha buscado automáticamente.");
        }

        if (slideVolume != null)
        {
            slideVolume.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
            AudioListener.volume = slideVolume.value;
            Mute();
        }
        else
        {
            Debug.LogError("slideVolume no está asignado en el Inspector.");
        }
    }

    void Update()
    {
        if (slideVolume != null)
        {
            slideVolume.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
            AudioListener.volume = slideVolume.value;
            Mute();
        }
    }

    public void Mute()
    {
        if (imageMuteO != null)
        {
            imageMuteO.enabled = (valueVolume == 0);
        }
        else
        {
            Debug.LogError("imageMuteO no está asignado en el Inspector.");
        }
    }
    public void VolumenSlide(float valor)
    {
        valueVolume = valor;
        PlayerPrefs.SetFloat("volumenAudio", valueVolume);
        AudioListener.volume = valueVolume;
        Mute();
    }
}
