using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ToggleEffect : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private float _speed;

    private bool _isFading = true;


    // Update is called once per frame
    void Update()
    {
        if (_isFading)
        {
            FadeOut();
            if (_text.alpha <= 0) _isFading = false;
        }
        else
        {
            FadeIn();
            if (_text.alpha >= 1) _isFading = true;
        }
    }

    private void FadeOut() => _text.alpha -= _speed * Time.deltaTime;

    private void FadeIn() => _text.alpha += _speed * Time.deltaTime;
}
