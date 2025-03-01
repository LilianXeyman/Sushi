using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class MenuInicio : MonoBehaviour
{
    [SerializeField]
    string SampleScene;

    [SerializeField]
    GameObject opcionesSonido;

    [SerializeField]
    float tiempoAnim;

    [SerializeField]
    LeanTweenType animCurv;

    private void Start()
    {
        LeanTween.scale(opcionesSonido, Vector2.zero, 0);
        opcionesSonido.SetActive(false);
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
}
