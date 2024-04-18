using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    [SerializeField]
    private float jumpspeed;
    [SerializeField]
    private float playerspeed;
    [SerializeField]
    private SpriteRenderer sr;
    [SerializeField]
    private Rigidbody2D rb;

    private bool pulando;
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private GameObject spawn;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(Input.GetAxis("Horizontal"));
        float x = Input.GetAxis("Horizontal");
        if (x < 0)
        {
            sr.flipX = true;
            animator.SetBool("correndo", true);
        }
        else if (x == 0)
        {
            animator.SetBool("correndo", false);
        }
        else
        {
            sr.flipX = false;
            animator.SetBool("correndo", true);
        }
        transform.Translate(new Vector3(x, 0, 0) * Time.deltaTime * playerspeed);
        pulo();

    }
    private void FixedUpdate()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Chão")
        {
            pulando = false;
            animator.SetBool("pulando", false);
        }


        if (collision.gameObject.tag == "inimigo")
        {
            transform.position = spawn.transform.position;

            this.morre();
        }

        if (collision.gameObject.tag == "fim")
        {
            transform.position = spawn.transform.position;

            this.morre();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Chão")
        {
            pulando = true;
        }
    }

    private void pulo()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !pulando)
        {

            rb.AddForce(
            new Vector2(0, jumpspeed), ForceMode2D.Impulse);
            animator.SetBool("pulando", true);
        };
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "fruta")
        {
            collision.gameObject.GetComponent<Animator>().SetBool("coletando", true);
            Destroy(collision.gameObject, 0.6f);


            Scene scene = SceneManager.GetActiveScene();
            if (scene.name == "Fase2")
            {
                GameController2.setPontos(1);
            }
            else
            {
                GameController.setPontos(1);
            }
        }
    }

    private void morre()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Fase2")
        {
            GameController2.perdeVida();
        }
        else
        {
            GameController.perdeVida();
        }

    }
}


