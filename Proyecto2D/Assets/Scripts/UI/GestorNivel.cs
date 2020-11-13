using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GestorNivel : MonoBehaviour
{
    //Aplicaria otras formas, pero ahora no tengo tiempo
    public static GestorNivel instance = null;

    public TextMeshProUGUI cantidadPuntaje;

    public TextMeshProUGUI cantidadSalud;

    float puntaje = 0f;

    public GameObject pausa;

    public GameObject meta;

    public GameObject gameOver;

    public Image panelFinal;

    Sequence secuencia;

    public bool pausado {get; set;}

    bool puedePausar;

    int nivelDestino;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != gameObject)
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update

    
    void Start()
    {
        nivelDestino = SceneManager.GetActiveScene().buildIndex;
        puedePausar = true;
        Time.timeScale = 1;
        cantidadPuntaje.text = puntaje.ToString();
        pausado = false;
    }

    private void Update()
    {
        
        if(SimpleInput.GetButtonDown("Cancel") && puedePausar)
        {
            PausarNivel();
        }
    }

    public void PausarNivel()
    {
        if(!pausado)
        {
            Time.timeScale = 0;
            pausado = true;
            pausa.SetActive(true);
        }else{
            pausado = false;
            Time.timeScale = 1;
            pausa.SetActive(false);
        }
    }

    public void AumentoPuntaje(float adicional)
    {
        puntaje += adicional;
        cantidadPuntaje.text = puntaje.ToString();
    }

    public void ActualizarSalud(float salud)
    {
        cantidadSalud.text = salud.ToString();
    }

    public void GameOver()
    {
        puedePausar = false;
        Time.timeScale = 0;
        gameOver.SetActive(true);

    }

    public void LlegoMeta()
    {
        puedePausar = false;
        StartCoroutine(TerminoNivel());
    }

    IEnumerator TerminoNivel(){
        secuencia = DOTween.Sequence();
        panelFinal.enabled = true;
        secuencia.Append(panelFinal.DOFade(1f,0.5f));
        yield return secuencia.WaitForCompletion();

        

        var nivelActual = PlayerPrefs.GetFloat("niveles",0);
        if(nivelDestino > nivelActual)
        {
            PlayerPrefs.SetFloat("niveles",nivelDestino);
           
        }

        GameManager.instance.FinalNivel();
        meta.SetActive(true);
    }

    
}
