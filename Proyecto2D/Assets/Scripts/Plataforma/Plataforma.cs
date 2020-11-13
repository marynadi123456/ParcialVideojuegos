
using UnityEngine;
using DG.Tweening;

public class Plataforma : MonoBehaviour
{
    Sequence secuencia;

    Transform posicionObjeto;

    public Vector3 posicionInicial;

    public Vector3 posicionFinal;
    // Start is called before the first frame update
    void Start()
    {
        posicionObjeto = GetComponent<Transform>();
        posicionInicial = posicionObjeto.position;

        MoverPlataforma();
        
    }

    void MoverPlataforma()
    {
        secuencia = DOTween.Sequence();
        secuencia.Append(posicionObjeto.DOMove(posicionFinal, 2f).SetEase(Ease.InOutSine).SetDelay(1f))
            .Append(posicionObjeto.DOMove(posicionInicial, 2f).SetEase(Ease.InOutSine).SetDelay(1f))
            .SetLoops(-1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(gameObject.transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(null);
        }
    }

}
