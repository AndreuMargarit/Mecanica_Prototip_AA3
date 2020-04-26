using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] Text timerText;

    private float secondsCounter = 0, 
        minutesCounter = 0, 
        hoursCounter = 0;

    public void SetTimerText(bool status)
    {
        timerText.gameObject.SetActive(status);
    }

    public void RestartTimer()
    {
        secondsCounter = 0;
        minutesCounter = 0;
        hoursCounter = 0;
    }

    void Update()
    {
        if (SpheresColorWinCondition._gameEnded) return;
        secondsCounter += Time.deltaTime;
        if (secondsCounter >= 60)
        {
            secondsCounter = 0;
            minutesCounter++;
        }
        else if (minutesCounter >= 60)
        {
            minutesCounter = 0;
            hoursCounter++;
        }
        timerText.text = hoursCounter.ToString("00") + ":" + minutesCounter.ToString("00") + ":" + ((int)secondsCounter).ToString("00");
    }
}
