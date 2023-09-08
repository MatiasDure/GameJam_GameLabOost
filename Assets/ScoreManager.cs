using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance { get; private set; }
    public int Score { get; set; }
    // public static float prevTime;

    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        } else {
            Destroy(this.gameObject);
        }
    }
    private void Start() {
        PlayerHealth.OnPlayerDeath += SaveScore;
    }
    private void SaveScore() {
        Score = Mathf.CeilToInt(Timer.instance.CurrentTime);
    }
    private void OnDestroy() {
        PlayerHealth.OnPlayerDeath -= SaveScore;
    }
}
