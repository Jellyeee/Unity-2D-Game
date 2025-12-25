using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_BUllet : MonoBehaviour
{

    public float s_speed;
    public float s_lifeTime;
    static public int hit_counter = 0;


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Boss")
        {
            Debug.Log("Bullet hit");
            if (hit_counter < 6)
            {
                hit_counter++;
            }
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "UI")
        {
            Destroy(gameObject);
        }

    }
    void Start()
    {
        Destroy(gameObject, s_lifeTime);
    }

    void Update()
    {
        transform.Translate(Vector2.up * s_speed * Time.deltaTime);

    }
}
