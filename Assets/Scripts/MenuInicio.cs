using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

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
        //Instanciar el coche y moverlo en el eje X con LeanTween. Que el recorrido lo haga en 2 s y luego se destruya  
        cocheInGame = Instantiate(coche, posInicialCoche, Quaternion.identity);
        timerCoche = timerCocheRestart;
    }
}
