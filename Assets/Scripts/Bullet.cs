using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float lifeTime;


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Bullet hit");
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "UI")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Boss")
        {
            Destroy(gameObject);
        }

    }
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
}
