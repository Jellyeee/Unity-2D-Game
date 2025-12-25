using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainSetting : MonoBehaviour
{
    public GameObject Setting_img;

    void Start()
    {
    }
    public void Setting_Title(GameObject button)
    {
        Player.Life = 10;
        SceneManager.LoadScene("TitleScene");
    }

    public void Setting_Setting(GameObject button)
    {
        Setting_img.SetActive(true);
    }

    public void Setting_Exit(GameObject button)
    {
        Application.Quit();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
                Setting_img.SetActive(false);
        }
        
        
    }
}
