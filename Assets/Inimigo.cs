using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    private float xInicial;
    private bool esquerda = true;
    private SpriteRenderer sr;
    [SerializeField]
    private float velocidade;
    [SerializeField]
    private float deslocamento;

    // Start is called before the first frame update
    void Start()
    {
        xInicial = transform.position.x;
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (esquerda)
        {
            sr.flipX = true;

            transform.Translate(new Vector2(-velocidade, 0) * Time.deltaTime);

            if(transform.position.x < xInicial - deslocamento) {
                esquerda = false;
            }
        }
        else
        {
            sr.flipX = false;
            transform.Translate(new Vector2(velocidade, 0) * Time.deltaTime);

            if(transform.position.x > xInicial + deslocamento) {
                esquerda = true;
            }
        }
    }
}
