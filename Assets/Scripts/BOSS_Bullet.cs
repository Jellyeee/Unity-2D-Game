using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class BOSS_Bullet : MonoBehaviour
{
    private Transform target;
    private Rigidbody2D rb;

    public float speed = 5f;
    public float rotateSpeed = 200f;
    public float lifeTime = 3f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        FixedUpdate();
        Destroy(gameObject, lifeTime);

    }


    void FixedUpdate()
    {
        target = GameObject.Find("Player").transform;

        Vector2 direction = (Vector2)target.position - rb.position;

        direction.Normalize();

       float rotateAmount = Vector3.Cross(direction , transform.up).z;

        rb.angularVelocity = -rotateAmount * rotateSpeed;

        rb.velocity = transform.up * speed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player.Life--;
            Destroy(gameObject);
        }
    }



}
