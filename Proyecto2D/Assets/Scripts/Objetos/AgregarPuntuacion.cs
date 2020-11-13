using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgregarPuntuacion : MonoBehaviour
{
    public float puntajeAdicional;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GestorNivel.instance.AumentoPuntaje(puntajeAdicional);
            //Sonido
            //GameManager.instance.AumentoPuntaje();
        }
    }
}
