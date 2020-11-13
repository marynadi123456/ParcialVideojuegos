using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPrincipal : MonoBehaviour
{
    public static UIPrincipal instance = null;
    // Start is called before the first frame update

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }else if(instance != gameObject)
        {
            Destroy(this.gameObject);
        }


    }
    void Start()
    {
        Time.timeScale = 1f;
    }
    
    

    public void SalirAplicacion()
    {
        Application.Quit();
    }

    public void BorrarDatos()
    {
        PlayerPrefs.DeleteAll();
    }

    
}
