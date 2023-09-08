using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public static Timer instance { get; private set; }
    // public static float prevTime;
    private float time;
    public float CurrentTime => time;
    [SerializeField] private TextMeshProUGUI TimerText;

    private void Awake() {
        if(instance == null) {
            instance = this;
        } else {
            Destroy(this.gameObject);
        }
    }
    private void Start() {
        
        ResetUI();
    }
    // Update is called once per frame
    void Update()
    {
        if (TimerText == null) { return; }
        time += Time.deltaTime;
        TimerText.text = "time: " + (int)time;
    }

    private void ResetUI() {
        time = 0;
        TimerText.text = "time: " + 0;
    }
}
