using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CambiarNivel : MonoBehaviour
{

    public Image panelImagen;
    Sequence secuencia;
    void Start()
    {
        if (panelImagen == null)
        {
            panelImagen = GetComponent<Image>();
        }
        StartCoroutine(IniciarNivel());
    }

    IEnumerator IniciarNivel()
    {
        secuencia = DOTween.Sequence();
        secuencia.Append(panelImagen.DOFade(0f, 0.5f)).SetUpdate(true);
        
        yield return secuencia.WaitForCompletion();
        panelImagen.enabled = false;
    }

    public void CargarNuevoNivel(int i)
    {
        StartCoroutine(CargandoNivel(i));
    }

    IEnumerator CargandoNivel(int i)
    {
        secuencia = DOTween.Sequence();
        panelImagen.enabled = true;
        secuencia.Append(panelImagen.DOFade(1f, 0.5f)).SetUpdate(true);
        yield return secuencia.WaitForCompletion();
        DOTween.KillAll();
        SceneManager.LoadSceneAsync(i);
        
    }

}
