using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;


public class Coleccionable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            GameManager.instance.SonidoColeccion(gameObject.tag);
            LeanPool.Despawn(gameObject);
            
            //Aqui pones para agregar sonido.... o en el otro que vas a crear.
        }    
    }
    
}
