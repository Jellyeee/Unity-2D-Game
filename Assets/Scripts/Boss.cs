using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    private Animator animator;
    public GameObject Boss_bullet;
    public Transform Boss_sPoint;
    public Transform Boss_sPoint2;
    public Transform Boss_sPoint3;
    public Transform Boss_sPoint4;
    public Transform Boss_sPoint5;
    public GameObject Txt1;
    public GameObject Txt2;
    public GameObject Txt3;
    public GameObject Txt4;
    public GameObject Txt5;
    public GameObject Txt6;
    public Slider HealthBar;
    public GameObject Boss_Health_bar;

    private Coroutine time;
    SpriteRenderer SpriteRenderer;

    private float timer;
    private int waitingTime;

    public float Enemy_life = 200;
    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        timer = 0.0f;
        waitingTime = 6;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {

            StartCoroutine("EnemyHit_Time");

            Enemy_life--;
            HealthBar.value = Enemy_life;

            if (Enemy_life <= 0)
            {
                Boss_Health_bar.SetActive(false);
                StartCoroutine(Die());
            }
        }

    }

    IEnumerator Die()
    {
        animator.SetBool("IsDead", true);
        Player.Life = 1000000;
        Destroy(gameObject, 5f);
        
        Txt1.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Txt2.SetActive(true);

        yield return new WaitForSeconds(0.3f);
        Txt3.SetActive(true);

        yield return new WaitForSeconds(0.3f);
        Txt4.SetActive(true);

        yield return new WaitForSeconds(0.3f);
        Txt5.SetActive(true);

        yield return new WaitForSeconds(0.5f);
        Txt6.SetActive(true);

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

            yield return new WaitForSeconds(0.02f);

            countTime++;
        }
        SpriteRenderer.color = new Color32(255, 255, 255, 255);


    }

    void Update()
    {

        
        timer += Time.deltaTime;


        if (timer > waitingTime)
        {

            if (Enemy_life > 0)
            {
                Instantiate(Boss_bullet, Boss_sPoint.transform.position, Boss_sPoint.transform.rotation);

                Instantiate(Boss_bullet, Boss_sPoint2.transform.position, Boss_sPoint.transform.rotation);

                Instantiate(Boss_bullet, Boss_sPoint3.transform.position, Boss_sPoint.transform.rotation);

                Instantiate(Boss_bullet, Boss_sPoint4.transform.position, Boss_sPoint.transform.rotation);

                Instantiate(Boss_bullet, Boss_sPoint5.transform.position, Boss_sPoint.transform.rotation);
                timer = 0;
            }

        }
    }
}


