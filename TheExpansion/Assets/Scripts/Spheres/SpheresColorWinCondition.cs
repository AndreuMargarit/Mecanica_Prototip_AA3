using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpheresColorWinCondition : MonoBehaviour
{
    [SerializeField] private ColorChangeScript[] _spheres;
    [SerializeField] private Text _text;
    [SerializeField] private Text _timerText;
    [SerializeField] private Text _endGameText;

    public static bool _gameEnded = true;
    public static Action _endGame = delegate { };

    private void Start()
    {
        UpdateCounter();
    }

    public void UpdateCounter()
    {
        float redSpheresCounter = 0;

        for(int i = 0; i < _spheres.Length; i++)
        {
            if (_spheres[i].IsRed) redSpheresCounter++;
        }

        int percentage = (int)((redSpheresCounter / _spheres.Length) * 100);
        _text.text = percentage.ToString() + '%';

        if(percentage >= 70)
        {
            _gameEnded = true;
            _endGame.Invoke();
            _endGameText.gameObject.SetActive(true);
            _endGameText.text = "Game Over \n Score: " + _timerText.text;
        }
    }
}
