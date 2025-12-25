using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpped = 5f;
    Animator anim;
    Vector3 inputPos;
    Vector2 Direction;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Player.Life > 0)
        { 
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");



        if (Input.GetMouseButton(0))
        {

            anim.SetBool("IsMove", false);



            if (Direction != Vector2.zero)
                anim.SetBool("IsShoot", true);
            else
                anim.SetBool("IsShoot", false);


            inputPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Direction = inputPos - transform.position;

            anim.SetFloat("inputX", Direction.x);
            anim.SetFloat("inputY", Direction.y);

            //transform.position = Vector2.MoveTowards(transform.position, inputPos, Time.deltaTime * moveSpped);
        }
        else
        {
            if (x != 0 || y != 0)
                anim.SetBool("IsMove", true);
            else
                anim.SetBool("IsMove", false);


            anim.SetFloat("inputX", x);
            anim.SetFloat("inputY", y);

        }
            transform.Translate(new Vector2(x, y) * Time.deltaTime * moveSpped);

        }
    }
}
