using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    private Transform target;
    public Vector2 M_direction;
    public float M_velocity;
    private float Zero_velocity;
    private float set_time;
    private bool is_press;

    void Start()
    {
        target = GameObject.Find("Player").transform;

        Zero_velocity = M_velocity;
        if (DayNight.Time_count == 1)
        {
            M_velocity += 0.005f;
        }
        else if (DayNight.Time_count == 0)
        {
            M_velocity = Zero_velocity;
        }
        set_time = 0f;
        is_press = false;


    }

    void Update()
    {
        // 함수 호출 지연으로 적의 이동을 멈춤
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(!is_press)
            {
                is_press = true;
                set_time = 100000f;
            }
            else
            {
                is_press = false;
                set_time = 0f;

            }
        }

        Invoke("MoveToTarget", set_time);


    }

    public void MoveToTarget()
    {

        M_direction = (target.position - transform.position).normalized;


        float distance = Vector2.Distance(target.position, transform.position);


        this.transform.position = new Vector2(transform.position.x + (M_direction.x * M_velocity), transform.position.y + (M_direction.y * M_velocity));


        if (this.transform.position.x < target.transform.position.x)
        {
            this.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if(this.transform.position.x > target.transform.position.x)
        {
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}

//https://pabian.wordpress.com/2015/01/14/%EC%9D%BC%EC%A0%95-%EA%B1%B0%EB%A6%AC%EC%95%88-%ED%94%8C%EB%A0%88%EC%9D%B4%EC%96%B4-%EC%B6%94%EC%A0%81/