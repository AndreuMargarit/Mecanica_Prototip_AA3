using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGameScript : MonoBehaviour
{
    [SerializeField] private GameObject _spheresContainer;

    [SerializeField] private Timer _timer;
    [SerializeField] private Text _percentageText;
    [SerializeField] private Text _gameOverText;

    public static Action _start = delegate { };

    private void Start()
    {
        SpheresColorWinCondition._endGame += GameEnded;
        _spheresContainer.SetActive(false);
    }

    public void StartGame()
    {
        _gameOverText.gameObject.SetActive(false);
        _spheresContainer.SetActive(true);
        _timer.RestartTimer();
        _timer.SetTimerText(true);
        _percentageText.gameObject.SetActive(true);
        _percentageText.text = "0%";
        SpheresColorWinCondition._gameEnded = false;

        for(int i = 0; i < _spheresContainer.transform.childCount; i++)
        {
            _spheresContainer.transform.GetChild(i).GetComponent<ColorChangeScript>().RestartSphere();
        }

        _start.Invoke();
        gameObject.SetActive(false);
    }

    private void GameEnded()
    {
        gameObject.SetActive(true);
        _spheresContainer.SetActive(false);
        _timer.SetTimerText(false);
        _percentageText.gameObject.SetActive(false);
    }
}
