using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour
{
    public GameObject rule_txt;
    public AudioSource MusicSource;
    public Slider Title_volume_Bar;
    static float Title_volume = 0.2f;

    public void SetMusicVolume(float volume)
    {
        Title_volume = volume;
    }

    void Start()
    {
        // 기존: GameManager.is_shot_gun = 0; DayNight.day_count = 1;
        // 변경: 싱글톤 GameManager로 초기화
        GameManager.Instance.InitializeGameData();

        Time.timeScale = 1f;
        Title_volume_Bar.value = Title_volume;
    }

    public void OnQuitButtonClick(GameObject button)
    {
        Application.Quit();
    }

    public void OnStartButtonClick(GameObject button)
    {
        SceneManager.LoadScene("MainScene");
    }

    public void OnRuleButtonClick(GameObject button)
    {
        rule_txt.SetActive(true);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            rule_txt.SetActive(false);
        }

        MusicSource.volume = Title_volume;
    }

}
