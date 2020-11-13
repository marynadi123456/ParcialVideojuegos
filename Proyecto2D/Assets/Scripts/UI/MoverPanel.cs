using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoverPanel : MonoBehaviour
{

    RectTransform posicionObjeto;

    

    public Vector3 destino;

    [Range(0f,1f)]

    public float velocidadMovimiento;

    Vector3 posicionOriginal;
    // Start is called before the first frame update
    void Start()
    {
        posicionObjeto =GetComponent<RectTransform>();
        posicionOriginal = posicionObjeto.anchoredPosition3D;

    }

    
    public void MoverDestino()
    {
        posicionObjeto.DOAnchorPos3D(destino,velocidadMovimiento);
        
    }

    public void MoverRegreso()
    {
        posicionObjeto.DOAnchorPos3D(posicionOriginal, velocidadMovimiento);
    }
}
