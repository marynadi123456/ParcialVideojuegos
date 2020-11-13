using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    AudioSource source;

    public AudioClip[] sonidos;

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

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
       

        source = GetComponent<AudioSource>();
    }

    public void SonidoColeccion(string tag)
    {
        switch (tag)
        {
            
            case "Secreto":
                source.PlayOneShot(sonidos[1]);
                break;
            default:
                source.PlayOneShot(sonidos[0]);
                break;
        }
    }

    public void DanoSalud()
    {
        source.PlayOneShot(sonidos[4]);
    }

    public void GameOver()
    {
        source.PlayOneShot(sonidos[3]);
    }

    public void FinalNivel()
    {
        source.PlayOneShot(sonidos[2]);
    }



    
}
