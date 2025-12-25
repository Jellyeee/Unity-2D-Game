using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPositon : MonoBehaviour
{
    public GameObject bullet;
    public GameObject s_bullet;
    public GameObject Gun_Angle;
    public Transform sPoint;
    public float timeBetweenShots;
    private float shotTime;
    Vector3 M_inputPos;
    Vector2 M_Direction;
    private AudioSource Gun_Audio;

    void Start()
    {
        Gun_Audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Player.Life > 0)
        {
            // 마우스 방향 → 총구 회전

            Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);


            M_inputPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            M_Direction = M_inputPos - transform.position;
            if (M_Direction.x > 0 && M_Direction.y > 0)
            {
                Gun_Angle.transform.rotation = Quaternion.Euler(0, 0, angle);

            }
            else if (M_Direction.x > 0 && M_Direction.y < 0)
            {
                Gun_Angle.transform.rotation = Quaternion.Euler(0, 0, angle);

            }
            else if (M_Direction.x < 0 && M_Direction.y < 0)
            {
                Gun_Angle.transform.rotation = Quaternion.Euler(180, 0, -angle);

            }
            else if (M_Direction.x < 0 && M_Direction.y > 0)
            {
                Gun_Angle.transform.rotation = Quaternion.Euler(180, 0, -angle);

            }

            // 좌클릭 → 총알 발사
            if (Input.GetMouseButton(0))
            {
                if (Time.time >= shotTime)
                {
                    Gun_Audio.Play();
                    //GameManager 싱글톤 사용
                    if (GameManager.Instance.ShotGun == 1)
                    {
                        for (int i = -2; i <= 2; i++) // 퍼지는 5발 샷건
                        {
                            Instantiate(bullet, sPoint.position, Quaternion.AngleAxis(angle - 90 + (i * 10), Vector3.forward));
                        }
                    }
                    else
                    {
                        Instantiate(bullet, sPoint.position, Quaternion.AngleAxis(angle - 90, Vector3.forward));
                    }
                    shotTime = Time.time + timeBetweenShots;

                }
            }
            // 스페셜 공격 (히트 카운터 충족 시)
            if (S_BUllet.hit_counter >= 6)
            {

                for (int i = 0; i < 15; i++)
                {
                    Instantiate(s_bullet, sPoint.position, Quaternion.AngleAxis(angle - 24 * i, Vector3.forward));

                }
                S_BUllet.hit_counter = 0;


            }
        }
    }

}
