using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]
    public static int pontos = 0;
    [SerializeField]
    private static TMP_Text Texto;
    [SerializeField]
    private static TMP_Text TextoVida;
    [SerializeField]
    private static int vida = 3;
    // Start is called before the first frame update
    void Start()
    {
        pontos = 0;
        vida = 3;
        GameObject go = GameObject.FindGameObjectWithTag("TextoPontos");
        GameObject go2 = GameObject.FindGameObjectWithTag("TextoVidas");

        Texto = go.GetComponent<TMP_Text>();
        TextoVida = go2.GetComponent<TMP_Text>();

        TextoVida.text = "Vidas: " + vida.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public static void setPontos(int ponto)
    {
        pontos += ponto;
        Texto.text = "Pontos: " + pontos.ToString();

        if(pontos == 4) {
            Debug.Log("acabou");
            SceneManager.LoadScene("Fase2");
        }
    }

    public static void perdeVida()
    {
        vida--;

        TextoVida.text = "Vidas: " + vida.ToString();
        if (vida <= 0) {
            Debug.Log("Game Over");
            SceneManager.LoadScene("GameOver");
        }
    }
}

