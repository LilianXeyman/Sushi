using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuInicio : MonoBehaviour
{
    public static MenuInicio Instance;
    
    [SerializeField]
    string SampleScene;

    [SerializeField]
    GameObject opcionesSonido;

    [SerializeField]
    float tiempoAnim;

    [SerializeField]
    LeanTweenType animCurv;

    //Timer para el coche
    [SerializeField]
    float timerCoche;
    [SerializeField]
    float timerCocheRestart;

    [SerializeField]
    GameObject coche;

    [SerializeField]
    public GameObject cocheInGame;

    [SerializeField]
    Vector2 posInicialCoche;

    [SerializeField]
    float posFinalCoche;

    [SerializeField]
    float tiempoAnimCoche;

    [SerializeField]
    LeanTweenType animCurvCoche;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    private void Start()
    {
        LeanTween.scale(opcionesSonido, Vector2.zero, 0);
        opcionesSonido.SetActive(false);
    }
    private void Update()
    { 
        timerCoche -= Time.deltaTime;
        if (timerCoche <= 0)
        {
            MoverCoche();
        }
    }
    public void Comenzar()
    {
        SceneManager.LoadScene(SampleScene);
    }
    public void Sonido()
    {
        if (opcionesSonido != null)
        {
            bool isActive = opcionesSonido.activeSelf;

            if (isActive)
            {
                LeanTween.scale(opcionesSonido, Vector2.zero, tiempoAnim).setEase(animCurv).setOnComplete(() =>
                {
                    opcionesSonido.SetActive(false);
                });
            }
            else
            {
                opcionesSonido.SetActive(true);
                LeanTween.scale(opcionesSonido, Vector2.one, tiempoAnim).setEase(animCurv);
            }
        }
    }
    void MoverCoche()
    {
        // Obtener el Canvas en la escena (Asegúrate de asignarlo en el Inspector)
        Canvas canvas = FindObjectOfType<Canvas>();
        if (canvas == null)
        {
            Debug.LogError("No se encontró un Canvas en la escena.");
            return;
        }

        // Instanciar el coche dentro del Canvas
        cocheInGame = Instantiate(coche, canvas.transform);
        cocheInGame.SetActive(true);

        // Obtener y ajustar el RectTransform
        RectTransform rectTransform = cocheInGame.GetComponent<RectTransform>();
        if (rectTransform == null)
        {
            Debug.LogError("El objeto instanciado no tiene un RectTransform.");
            return;
        }

        rectTransform.anchoredPosition = posInicialCoche; // Ajustar la posición inicial
        //rectTransform.sizeDelta = new Vector2(200, 100); // Ajustar tamaño

        // Verificar que la imagen está activa
        Image img = cocheInGame.GetComponent<Image>();
        if (img != null)
        {
            img.enabled = true;
            img.color = Color.white;
        }
        else
        {
            Debug.LogError("El coche instanciado no tiene un componente Image.");
        }

        // Mover el coche con LeanTween
        LeanTween.moveX(rectTransform, posFinalCoche, tiempoAnimCoche)
            .setEase(animCurvCoche)
            .setOnComplete(() => {
                Destroy(cocheInGame.gameObject);
            });

        timerCoche = timerCocheRestart;
    }
}
