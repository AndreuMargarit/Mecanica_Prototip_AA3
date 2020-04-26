using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ColorChangeScript : MonoBehaviour
{
    private const float MIN_TIME = 5;
    private const float MAX_TIME = 10;

    private const float ANIMATION_COLOR_TIME = 5;

    [SerializeField] private Color _regularColor = new Color();
    [SerializeField] private Color _wrongColor = new Color();

    [SerializeField] private bool _stopAnimation = false;

    [SerializeField] private bool _animateStart = false;

    [SerializeField] private ColorChangeScript[] _spheres = new ColorChangeScript[] {};

    private Material _material;
    private Tween _tweenToRed;
    private Coroutine _coroutine;
    private bool _isRed = false;

    public bool IsRed { get => _isRed; }

    private void Awake()
    {
        StartGameScript._start += StartAnimationsOnStart;
        _material = GetComponent<MeshRenderer>().material;
        _material.SetColor("_Color", _regularColor);

        _tweenToRed = _material.DOColor(_wrongColor, ANIMATION_COLOR_TIME)
            .Pause()
            .SetAutoKill(false)
            .SetEase(Ease.Linear)
            .OnPlay(AnimationStart)
            .OnComplete(FinishedColorAnimation);

        StartColorAnimationCoroutine();
        StopCoroutine(_coroutine);
    }

    public void RestartSphere()
    {
        StopCoroutine(_coroutine);
        _tweenToRed.Pause();
        _material.SetColor("_Color", _regularColor);
        _isRed = false;
    }

    private void StartAnimationsOnStart()
    {
        if (_animateStart)
            StartColorAnimationCoroutine();
    }

    public void TriggerStopAnimation()
    {
        if (SpheresColorWinCondition._gameEnded) return;

        if (_tweenToRed.IsPlaying() || _isRed == true)
        {
            StopAnimation();
            _material.SetColor("_Color", _regularColor);

            StopCoroutine(_coroutine);

            StartColorAnimationCoroutine();
            _stopAnimation = false;
        }
    }

    private void StartColorAnimationCoroutine()
    {
        _coroutine = StartCoroutine(StartExparsion(Random.Range(MIN_TIME, MAX_TIME)));
    }

    private IEnumerator StartExparsion(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        StartAnimation();
    }

    private void StartAnimation()
    {
        if (!_tweenToRed.IsPlaying())
        {
            _isRed = false;
            GameObject.Find("Text (1)").GetComponent<SpheresColorWinCondition>().UpdateCounter();
            _tweenToRed.Restart();
            StopCoroutine(_coroutine);
        }
    }

    private void StopAnimation()
    {
        _isRed = false;
        GameObject.Find("Text (1)").GetComponent< SpheresColorWinCondition>().UpdateCounter();
        _tweenToRed.Pause();
    }

    private void AnimationStart()
    {

    }

    private void FinishedColorAnimation()
    {
        _isRed = true;
        GameObject.Find("Text (1)").GetComponent<SpheresColorWinCondition>().UpdateCounter();
        foreach (ColorChangeScript sphere in _spheres)
        {
            if(!sphere._isRed)
                sphere.StartAnimation();
        }
    }

    private void OnDrawGizmos()
    {
        foreach(ColorChangeScript sphere in _spheres)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, sphere.transform.position);
        }
    }
}
