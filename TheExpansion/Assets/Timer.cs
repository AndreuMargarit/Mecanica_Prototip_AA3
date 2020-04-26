using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] Text timerText;
    private float secondsCounter = 0, minutesCounter = 0, hoursCounter = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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
