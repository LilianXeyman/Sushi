using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextoPersonaje : MonoBehaviour
{
    public TMP_Text myTMPText;
    public AudioSource audioSource;
    public AudioClip sonidoHablar;
    // �ndice para controlar el di�logo
    private int dialogoIndex = 0;

    // Botones
    [SerializeField] GameObject boton1;
    [SerializeField] GameObject boton2;
    [SerializeField] GameObject boton3;

    // Di�logos
    private readonly string[] dialogos =
    {
        "�Ohayoo y bienvenido a Sushi & Co.: el imperio del Sashimi! \r\nSoy Sensei Nobu, tu mentor y compa�ero en esta aventura culinaria.",
        "�Sab�as que este peque�o restaurante esconde una leyenda? Mi difunto Maestro Kaito, tu ancestro, sol�a decir:",
        "'El sushi es poes�a y cada rollo, un verso que conquista corazones'",
        "�Y hoy, t� tienes la oportunidad de escribir nuevos cap�tulos en esta historia!",
        "Hoy comenzar�s tu aventura para convertir este restaurante en el mejor de la ciudad",
        "Pero antes de ensuciarte las manos, dime, �qu� te gustar�a saber primero?"
    };

    private bool escribiendo = false; // Bloquea la entrada mientras escribe

    void Start()
    {
        // Inicializar botones desactivados
        boton1.SetActive(false);
        boton2.SetActive(false);
        boton3.SetActive(false);

        // Iniciar el primer texto con animaci�n
        StartCoroutine(EscribirTexto(dialogos[dialogoIndex]));
    }

    void Update()
    {
        if (Input.GetButtonDown("Submit") && !escribiendo && dialogoIndex < dialogos.Length - 1)
        {
            dialogoIndex++;
            StartCoroutine(EscribirTexto(dialogos[dialogoIndex]));

            // Si es el �ltimo di�logo, mostrar botones
            if (dialogoIndex == dialogos.Length - 1)
            {
                boton1.SetActive(true);
                boton2.SetActive(true);
                boton3.SetActive(true);
            }
        }
    }

    IEnumerator EscribirTexto(string texto)
    {
        escribiendo = true; // Bloquear input mientras se escribe
        myTMPText.text = ""; // Limpiar el texto antes de escribir
        if (audioSource != null && sonidoHablar != null)
        {
            audioSource.PlayOneShot(sonidoHablar);
        }
        foreach (char letra in texto)
        {
            myTMPText.text += letra;
            yield return new WaitForSeconds(0.02f); // Controla la velocidad de escritura
        }

        escribiendo = false; // Permitir input despu�s de escribir
    }
}
