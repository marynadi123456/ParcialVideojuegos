using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Niveles : MonoBehaviour
{

    public Button[] niveles;

    float nivelDesbloqueado;

    

    // Start is called before the first frame update
    void Start()
    {

        nivelDesbloqueado = PlayerPrefs.GetFloat("niveles", 0);
        
        for (int i = 0; i < niveles.Length; i++)
        {
            if(i<= nivelDesbloqueado)
            {
                niveles[i].interactable = true;
            }
            else
            {
                niveles[i].interactable = false;
            }
        }
    }

    
}
