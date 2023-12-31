using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerSwitch : MonoBehaviour
{
    [SerializeField] private float _time;
    [SerializeField] private string _sceneToSwitch;
    [SerializeField] private TextMeshProUGUI _countdown;
    [SerializeField] private float _fontSize = 50;

    // Update is called once per frame
    void Update()
    {
        _time -= Time.deltaTime;

        TextEffect();

        if (_time > 0) return;

        SceneManager.Instance.SwitchScene(_sceneToSwitch);
    }

    private void TextEffect()
    {
        float remainders = _time % (int)_time;
        _countdown.text = "" + (int)_time;
        _countdown.fontSize = remainders * _fontSize;
        _countdown.alpha = remainders;
    }
}
