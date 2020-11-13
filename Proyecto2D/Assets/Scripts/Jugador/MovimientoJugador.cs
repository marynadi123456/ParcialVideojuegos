using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{

    public float velocidadJugador;

    public float fuerzaSalto;

    public float saltoTiempo;

    public LayerMask layerSuelo;

    public Transform pies;

    Rigidbody2D cuerpo;

    Collider2D colliderJugador;

    float horizontal;

    bool enSuelo;

    bool saltando;

    float tiempoAire;

    // Start is called before the first frame update
    void Start()
    {
        cuerpo = GetComponent<Rigidbody2D>();
        colliderJugador = GetComponent<Collider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        horizontal = SimpleInput.GetAxis("Horizontal");
        enSuelo = Physics2D.OverlapCircle(pies.position, 0.3f, layerSuelo);

        if(horizontal > 0)
        {
            transform.eulerAngles = new Vector3(0,0,0);
        }else if(horizontal< 0)
        {
            transform.eulerAngles = new Vector3(0,180,0);
        }

        if(SimpleInput.GetButtonDown("Jump") && enSuelo)
        {
            tiempoAire = saltoTiempo;
            saltando = true;
            cuerpo.velocity = new Vector2(cuerpo.velocity.x, fuerzaSalto);
            
        }

        if (SimpleInput.GetButton("Jump") && saltando)
        {
            if (tiempoAire > 0)
            {
                cuerpo.velocity = new Vector2(cuerpo.velocity.x, fuerzaSalto);
                tiempoAire -= Time.deltaTime;
            }
            else
            {
                saltando = false;
            }
        }

        if (SimpleInput.GetButtonUp("Jump"))
        {
            saltando = false;
        }
        /*

        Por alguna razon, al mantener presionado el boton, no puedo moverse de izquierda a derecha
        Tengo que ver que pasa aqui.
       
        
        */



    }

    private void FixedUpdate() 
    {
        //enSuelo = Physics2D.OverlapCircle(pies.position, 0.1f, layerSuelo);
        cuerpo.velocity = new Vector2(horizontal * velocidadJugador, cuerpo.velocity.y);
    }

    public void Salto()
    {
        
    }
}
