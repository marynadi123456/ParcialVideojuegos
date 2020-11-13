using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salud : MonoBehaviour
{

    public float saludMaxima;

    float saludActual;

    public float invisibilidad;

    bool invisible;
    // Start is called before the first frame update
    void Start()
    {
        invisible = false;
        saludActual = saludMaxima;

        GestorNivel.instance.ActualizarSalud(saludActual);
    }


    public void RecibirDano()
    {

    }

    public void RestaurarSalud(float adicional)
    {
        if (saludActual < saludMaxima)
        {
            saludActual += adicional;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*
        
         */
        if (collision.gameObject.CompareTag("Obstaculo"))
        {
            if (!invisible)
            {
                invisible = true;
                saludActual--;
                GestorNivel.instance.ActualizarSalud(saludActual);
                if (saludActual > 0)
                {
                    GameManager.instance.DanoSalud();
                    StartCoroutine(InvisibilidadTemporal());
                }
                else
                {
                    GestorNivel.instance.GameOver();
                    //Aqui llamas para que se paralice el juego y llama al GameOver.
                }
                
            }
        }
    }

    IEnumerator InvisibilidadTemporal()
    {
        var tiempo = invisibilidad;
        
        yield return new WaitForSeconds(tiempo);
        invisible = false;

    }
}
