using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UITimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public GameObject timerUiGo;
    public TextMeshProUGUI timerTextEndScreen;

    private float startTime;
    private int currentTime;
    private int minutes;
    private int seconds;
    private bool isActive = false;
    private string textSave;

    // Start is called before the first frame update
    void Start()
    {
        //timerText.text = "00:00";
        startTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(startTime > 0.0f && isActive)
        {
            currentTime = (int)(Time.time - startTime);

            minutes = currentTime / 60;
            seconds = currentTime - (minutes * 60);
            textSave = minutes.ToString("D2") + ":" + seconds.ToString("D2");
            timerText.text = textSave;

        }
    }

    public void StartTimer()
    {
        startTime = Time.time;
        isActive = true;
        timerUiGo.SetActive(true);
    }

    public void StopTimer()
    {
        isActive = false;
        timerUiGo.SetActive(false);
        timerTextEndScreen.text = textSave;
    }

}
