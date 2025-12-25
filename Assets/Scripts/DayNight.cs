using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayNight : MonoBehaviour
{
    public SpriteRenderer sr;
    public Text TimeText;
    public Text DayText;

    public Color day;
    public Color midnight;
    public Color midnight2;
    public Color night;

    public float oneDay;
    public float currentTime;

    [Range(0.01f,0.2f)]
    public float Transition_TIme;

    static public int Time_count = 0;
    static public int day_count = 1;

    private Color pause_color;

    bool isSwap = false;

    private void Awake()
    {
        float spritex = sr.sprite.bounds.size.x;
        float spritey = sr.sprite.bounds.size.y;

        float screenY = Camera.main.orthographicSize * 2;
        float screenX = screenY / Screen.height * Screen.width;
        transform.localScale = new Vector2(Mathf.Ceil(screenX / spritex), Mathf.Ceil(screenY / spritey));

    }

    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        StartCoroutine(SwapColor(sr.color, pause_color));

        currentTime += Time.deltaTime;
        if (currentTime >= oneDay)
        {
            day_count++;
            currentTime = 0;
            Player.Life = 10;
        }

        if (currentTime <= 20)
        {
           TimeText.text = "Day";

        }
        else if (currentTime <= 40)
        {
            TimeText.text = "Day";

        }
        else if (currentTime > 40)
        {
           TimeText.text = "Night";
            
        }
        else if (currentTime > 60)
        {
            TimeText.text = "MidNight";

        }



        if (!isSwap)
        {
            if (day_count == 6)
            {
                currentTime = 0;
                isSwap = false;
                Time_count = 1;
                pause_color = night;
                StartCoroutine(SwapColor(sr.color, pause_color));

            }
            else if (Mathf.FloorToInt(oneDay * 0.2f) == Mathf.FloorToInt(currentTime))
            {
                isSwap = true;
                Time_count = 0;
                pause_color = midnight;
                StartCoroutine(SwapColor(sr.color, pause_color));


            }
            else if (Mathf.FloorToInt(oneDay * 0.4f) == Mathf.FloorToInt(currentTime))
            {
                isSwap = true;
                Time_count = 1;
                pause_color = midnight2;
                StartCoroutine(SwapColor(sr.color, pause_color));


            }
            else if (Mathf.FloorToInt(oneDay * 0.6f) == Mathf.FloorToInt(currentTime))
            {
                isSwap = true;
                Time_count = 1;
                pause_color = night;
                StartCoroutine(SwapColor(sr.color, pause_color));


            }
            else if (Mathf.FloorToInt(oneDay * 0.99f) == Mathf.FloorToInt(currentTime))
            {
                isSwap = true;
                Time_count = 0;
                pause_color = day;
                StartCoroutine(SwapColor(sr.color, pause_color));


            }

            DayText.text = "Day : " + day_count;
        }


        IEnumerator SwapColor(Color start, Color end)
        {
            float t = 0;
            while(t<1)
            {
                t += Time.deltaTime * (1/(Transition_TIme * oneDay));
                sr.color = Color.Lerp(start, end, t);
                yield return null;
            }
        }
        isSwap = false;
    }
}
