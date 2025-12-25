using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Rigidbody2D rigid;
    SpriteRenderer SpriteRenderer;
    public Text LifeText;
    public GameObject RestartText;
    static public float Life = 10;

    Animator animator;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponentInChildren<Animator>();
        Time.timeScale = 1f;
    }


    void Update()
    {
        if (Life < 0)
            Life = 0;
        LifeText.text = " x " + Life;
        if (Life <= 0)
        {
            if (Input.GetKeyDown("r"))
            {
                GameManager.is_Magnum = 0;
                GameManager.is_shot_gun = 0;
                GameManager.is_Riffle = 1;
                Restart();
            }
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DeadZone")
        {
            Life -= 10;
        }
            if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Boss")
        {
                Debug.Log("Player hit");

                Life--;
        
            if(Life > 1)
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                StartCoroutine("unHit_Time");
            }
        }

        if (Life <= 0)
        {
            Die();
        }

    }

    IEnumerator unHit_Time()
    {
        int countTime = 0;

    

        while (countTime < 10)
        {
            if (countTime % 2 == 0)
                SpriteRenderer.color = new Color32(255, 255, 255, 90);
            else
                SpriteRenderer.color = new Color32(255, 255, 255, 180);

            yield return new WaitForSeconds(0.3f);

            countTime++;
        }
        SpriteRenderer.color = new Color32(255, 255, 255, 255);

        gameObject.GetComponent<BoxCollider2D>().enabled = true;

        yield return null;
    }

    void Die()
    {

        rigid.velocity = Vector2.zero;

        animator.Play("Player_die");

        gameObject.GetComponent<BoxCollider2D>().enabled = false;

        RestartText.SetActive(true);

 
    }

    void Restart()
    {
        SceneManager.LoadScene("MainScene");

        Life = 10;
    }
}
