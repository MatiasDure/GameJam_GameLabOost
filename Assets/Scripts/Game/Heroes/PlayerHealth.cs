using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
    public static PlayerHealth Instance { get; private set; }
    public int HP { get; private set; }
    [SerializeField] private Image heart1;
    [SerializeField] private Image heart2;
    private void Awake() {
        if (Instance == null) Instance = this;
        else Destroy(this.gameObject);
    }
    // Start is called before the first frame update
    void Start() {
        ResetHP();
        Hero.OnObstacleHit += DecreaseHP;
    }

    // Update is called once per frame
    void Update() {

    }
    private void ResetHP() {
        HP = 2;
    }

    private void DecreaseHP() {
        HP -= 1;
        if (HP <= 1) {
            Death();
        }
        if(HP == 1) {

        }
    }

    private void Death() {
        SceneManager.Instance.SwitchScene("GameOver");
    }

    private void OnDestroy()
    {
        Hero.OnObstacleHit -= DecreaseHP;
    }
}
