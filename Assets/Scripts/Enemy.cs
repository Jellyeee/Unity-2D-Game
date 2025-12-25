using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D Enemy_Rigidbody;
    SpriteRenderer SpriteRenderer;

    public float Enemy_life = 2;

    void Start()
    {
        animator = GetComponent<Animator>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            StartCoroutine("EnemyHit_Time");
            Enemy_life--;
            print("Enemy hit");
            if (Enemy_life <= 0)
            {
                Die();
            }
        }

    }

    private void Die()
    {

        animator.SetBool("IsDead", true);

        Destroy(gameObject,1f);
    }

    IEnumerator EnemyHit_Time()
    {
        int countTime = 0;



        while (countTime < 10)
        {
            if (countTime % 2 == 0)
                SpriteRenderer.color = new Color32(255, 0, 0, 80);
            else
                SpriteRenderer.color = new Color32(255, 255, 255, 255);

            yield return new WaitForSeconds(0.05f);

            countTime++;
        }
        SpriteRenderer.color = new Color32(255, 255, 255, 255);



    }

}
