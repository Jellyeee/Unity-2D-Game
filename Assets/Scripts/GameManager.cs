using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject Enemy_1;
    public GameObject Enemy_2;
    public GameObject Enemy_3;
    public GameObject Enemy_4;

    public GameObject Enemy_5;
    public GameObject Enemy_6;
    public GameObject Enemy_7;
    public GameObject Enemy_8;

    public GameObject Enemy_9;
    public GameObject Enemy_10;
    public GameObject Enemy_11;
    public GameObject Enemy_12;
    public GameObject BOSS;
    public GameObject FlameThrower;

    public Text Special_Text;
    public GameObject S_txt;
    public GameObject Setting_Screen;
    public GameObject Setting_img;
    private bool is_Setting_Screen;

    public GameObject Boss_start1;
    public GameObject Boss_start2;
    public GameObject Boss_start3;
    public GameObject Boss_start4;
    private bool is_start_boos;

    private bool isPause;
    private int count = 2;        //생성할 게임 오브젝트의 개수
    private BoxCollider2D area;     //BoxCollider2D의 사이즈를 가져오기 위한 변수
    private List<GameObject> EnemyList = new List<GameObject>();		//생성한 오브젝트 리스트

    public GameObject BGM;
    public GameObject BOSS_BGM;
    public GameObject Boss_Health_bar;

    static public int is_shot_gun = 0;
    static public int is_Riffle = 0;
    static public int is_Magnum = 0;

    public AudioSource Main_BGM;
    public AudioSource Main_Boss_BGM;
    public AudioSource Riffle_sound;
    public AudioSource shot_gun_sound;
    public AudioSource Magnum_sound;

    public Slider Main_BGM_Bar;
    public Slider Main_Boss_BGM_Bar;
    public Slider Riffle_sound_Bar;
    public Slider shot_gun_sound_Bar;
    public Slider Magnum_sound_Bar;


    static float Main_BGM_volume = 0.05f;
    static float Main_Boss_volume = 0.01f;
    static float Riffle_volume = 0.02f;
    static float Shot_gun_volume = 0.07f;
    static float Magnum_volume = 0.03f;


    // 싱글톤 인스턴스
    public static GameManager Instance { get; private set; }

    // 관리할 전역 데이터
    public int ShotGun { get; private set; }
    public int Riffle { get; private set; }
    public int Magnum { get; private set; }
    public int DayCount { get; private set; }

    // 무기 오브젝트 참조 (인스펙터에서 연결)
    public GameObject MagnumObj;
    public GameObject FlameThrowerObj;
    public GameObject RiffleObj;
    public GameObject S_txtObj;

    void Awake()
    {
        // 싱글톤 보장
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        InitializeGameData();
    }

    // 초기화 함수
    public void InitializeGameData()
    {
        ShotGun = 0;
        Magnum = 0;
        Riffle = 1;
        DayCount = 1;
    }

    // 데이터 수정 함수 (캡슐화)
    public void AddShotGun(int value) => ShotGun += value;
    public void AddMagnum(int value) => Magnum += value;
    public void AddRiffle(int value) => Riffle += value;
    public void NextDay() => DayCount++;

    // 무기 전환 함수
    public void SwitchWeapon(int weaponType)
    {
        switch (weaponType)
        {
            case 1: // Rifle
                ShotGun = 0; Riffle = 1; Magnum = 0;
                MagnumObj.SetActive(false);
                FlameThrowerObj.SetActive(false);
                RiffleObj.SetActive(true);
                S_txtObj.SetActive(false);
                break;

            case 2: // Shotgun
                ShotGun = 1; Riffle = 0; Magnum = 0;
                MagnumObj.SetActive(false);
                FlameThrowerObj.SetActive(true);
                RiffleObj.SetActive(false);
                S_txtObj.SetActive(false);
                break;

            case 3: // Magnum
                ShotGun = 0; Riffle = 1; Magnum = 1;
                MagnumObj.SetActive(true);
                FlameThrowerObj.SetActive(false);
                RiffleObj.SetActive(false);
                S_txtObj.SetActive(true);
                break;
        }
    }

    public void SetMusicVolume(float volume)
    {
        Main_BGM_volume = volume;
    }
    public void SetMusicVolume2(float volume)
    {
        Main_Boss_volume = volume;
    }
    public void SetMusicVolume3(float volume)
    {
        Riffle_volume = volume;
    }
    public void SetMusicVolume4(float volume)
    {
        Shot_gun_volume = volume;
    }
    public void SetMusicVolume5(float volume)
    {
        Magnum_volume = volume;
    }

    public void Back_Button_In_Setting_Click(GameObject button)
    {
        Setting_img.SetActive(false);
    }

    void Start()
    {
        area = GetComponent<BoxCollider2D>();
        StartCoroutine("Spawn", 20);
        isPause = false;
        is_Setting_Screen = false;
        is_start_boos = false;
        BGM.SetActive(true);
        BOSS_BGM.SetActive(false);

        Main_BGM_Bar.value = Main_BGM_volume;
        Main_Boss_BGM_Bar.value = Main_Boss_volume;
        Riffle_sound_Bar.value = Riffle_volume;
        shot_gun_sound_Bar.value = Shot_gun_volume;
        Magnum_sound_Bar.value = Magnum_volume;
    }

    //게임 오브젝트를 복제하여 scene에 추가
    private IEnumerator Spawn(float delayTime)
    {

        for (int i = 0; i < count; i++) //count만큼 생성
        {
            Vector3 spawnPos_1 = GetRandomPosition(); //랜덤 위치 return

            //원본, 위치, 회전값을 매개변수로 받아 오브젝트 복제
            GameObject instance_1 = Instantiate(Enemy_1, spawnPos_1, Quaternion.identity);

            Vector3 spawnPos_2 = GetRandomPosition(); //랜덤 위치 return

            GameObject instance_2 = Instantiate(Enemy_2, spawnPos_2, Quaternion.identity);

            Vector3 spawnPos_3 = GetRandomPosition(); //랜덤 위치 return

            GameObject instance_3 = Instantiate(Enemy_3, spawnPos_3, Quaternion.identity);

            Vector3 spawnPos_4 = GetRandomPosition(); //랜덤 위치 return

            GameObject instance_4 = Instantiate(Enemy_4, spawnPos_4, Quaternion.identity);


            if (DayNight.Time_count > 0)
            {

                if (DayNight.day_count == 2 || DayNight.day_count >= 4)
                {
                    Vector3 spawnPos_5 = GetRandomPosition(); //랜덤 위치 return

                    GameObject instance_5 = Instantiate(Enemy_5, spawnPos_5, Quaternion.identity);

                    Vector3 spawnPos_6 = GetRandomPosition(); //랜덤 위치 return

                    GameObject instance_6 = Instantiate(Enemy_6, spawnPos_6, Quaternion.identity);

                    Vector3 spawnPos_7 = GetRandomPosition(); //랜덤 위치 return

                    GameObject instance_7 = Instantiate(Enemy_7, spawnPos_7, Quaternion.identity);

                    Vector3 spawnPos_8 = GetRandomPosition(); //랜덤 위치 return

                    GameObject instance_8 = Instantiate(Enemy_8, spawnPos_8, Quaternion.identity);

                    EnemyList.Add(instance_5); //오브젝트 관리를 위해 리스트에 add
                    EnemyList.Add(instance_6); //오브젝트 관리를 위해 리스트에 add
                    EnemyList.Add(instance_7); //오브젝트 관리를 위해 리스트에 add
                    EnemyList.Add(instance_8); //오브젝트 관리를 위해 리스트에 add

                }


                if (DayNight.day_count > 2)
                {
                    Vector3 spawnPos_9 = GetRandomPosition(); //랜덤 위치 return

                    GameObject instance_9 = Instantiate(Enemy_9, spawnPos_9, Quaternion.identity);

                    Vector3 spawnPos_10 = GetRandomPosition(); //랜덤 위치 return

                    GameObject instance_10 = Instantiate(Enemy_10, spawnPos_10, Quaternion.identity);

                    Vector3 spawnPos_11 = GetRandomPosition(); //랜덤 위치 return

                    GameObject instance_11 = Instantiate(Enemy_11, spawnPos_11, Quaternion.identity);

                    Vector3 spawnPos_12 = GetRandomPosition(); //랜덤 위치 return

                    GameObject instance_12 = Instantiate(Enemy_12, spawnPos_12, Quaternion.identity);
                    EnemyList.Add(instance_9); //오브젝트 관리를 위해 리스트에 add
                    EnemyList.Add(instance_10); //오브젝트 관리를 위해 리스트에 add
                    EnemyList.Add(instance_11); //오브젝트 관리를 위해 리스트에 add
                    EnemyList.Add(instance_12); //오브젝트 관리를 위해 리스트에 add
                }




            }
            EnemyList.Add(instance_1); //오브젝트 관리를 위해 리스트에 add
            EnemyList.Add(instance_2); //오브젝트 관리를 위해 리스트에 add
            EnemyList.Add(instance_3); //오브젝트 관리를 위해 리스트에 add
            EnemyList.Add(instance_4); //오브젝트 관리를 위해 리스트에 add

        }

        area.enabled = false;
        yield return new WaitForSeconds(delayTime);   //주기 : 20초

        for (int i = 0; i < count; i++) //삭제
            Destroy(EnemyList[i].gameObject);

        EnemyList.Clear();           //List 비우기
        area.enabled = true;
        if (DayNight.day_count != 6)
        {

            StartCoroutine("Spawn", 10);    //다시 스폰
        }
    }

    //BoxCollider2D 내의 랜덤한 위치를 return
    private Vector2 GetRandomPosition()
    {
        Vector2 basePosition = transform.position;  //오브젝트의 위치
        Vector2 size = area.size;                   //box colider2d, 즉 맵의 크기 벡터
        float posX = 0f;
        float posY = 0f;


        //x, y축 랜덤 좌표 얻기
        posX = basePosition.x + Random.Range(-size.x / 3f, size.x / 3f);
        posY = basePosition.y + Random.Range(-size.y / 3f, size.y / 3f);



        Vector2 spawnPos = new Vector2(posX, posY);

        return spawnPos;

    }

    void Update()
    {
        Main_BGM.volume = Main_BGM_volume;
        Main_Boss_BGM.volume = Main_Boss_volume;
        Riffle_sound.volume = Riffle_volume;
        shot_gun_sound.volume = Shot_gun_volume;
        Magnum_sound.volume = Magnum_volume;

        if (Input.GetKeyDown("p"))
        {
            DayNight.day_count++;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!is_Setting_Screen)
            {
                is_Setting_Screen = true;
                Setting_Screen.SetActive(true);
            }
            else
            {
                is_Setting_Screen = false;
                Setting_Screen.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPause)
            {
                isPause = true;
                Time.timeScale = 0f;
            }
            else
            {
                isPause = false;
                Time.timeScale = 1f;
            }
        }

        if (Input.GetKeyDown("1"))
        {
            GameManager.Instance.SwitchWeapon(1);
        }
        else if (Input.GetKeyDown("2"))
        {
            GameManager.Instance.SwitchWeapon(2);
        }
        else if (Input.GetKeyDown("3"))
        {
            GameManager.Instance.SwitchWeapon(3);
        }

        Special_Text.text = "" + S_BUllet.hit_counter;

        if (DayNight.day_count == 6)
        {
            if (!is_start_boos)
            {
                BGM.SetActive(false);
                BOSS_BGM.SetActive(true);
                StartCoroutine(Boss_Start_Scene());
                is_start_boos = true;
            }
            
        }
    }

    IEnumerator Boss_Start_Scene()
    {
        Boss_start1.SetActive(true);
        yield return new WaitForSeconds(0.5f);

        Boss_start2.SetActive(true);
        yield return new WaitForSeconds(0.5f);

        Boss_start3.SetActive(true);
        yield return new WaitForSeconds(0.5f);

        Boss_start4.SetActive(true);

        yield return new WaitForSeconds(3f);

        Boss_start1.SetActive(false);
        Boss_start2.SetActive(false);
        Boss_start3.SetActive(false);
        Boss_start4.SetActive(false);

        yield return new WaitForSeconds(0.5f);

        Boss_Health_bar.SetActive(true);
        if (BOSS != null)
            BOSS.SetActive(true);
        Player.Life = 10;
    }
}
    