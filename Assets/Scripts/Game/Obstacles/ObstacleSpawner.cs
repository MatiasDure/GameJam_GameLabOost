using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] float _spawnTime;

    private float _spawnTimer;
    public float spawnTimeDecreaser;

    private void Start()
    {
        spawnTimeDecreaser = 1;
        ResetTimer();
    }

    // Update is called once per frame
    void Update()
    {
        Countdown();

        if (_spawnTimer > 0) return;

        SpawnObstacle();
        ResetTimer();

        CheckToDecrese();
    }

    private void CheckToDecrese() {
        if (Mathf.Floor(Timer.instance.CurrentTime / 5) != spawnTimeDecreaser && spawnTimeDecreaser < 14) {
            spawnTimeDecreaser = Mathf.Floor(Timer.instance.CurrentTime / 5);
            _spawnTime -= 0.2f;
        }
    }

    private void Countdown() => _spawnTimer -= Time.deltaTime; 

    private void ResetTimer()
    {
        _spawnTimer = _spawnTime;
    }

    private void SpawnObstacle()
    {
        Obstacle unPooledObstacle = ObstaclePooler.Instance.EnableObstacle();

        unPooledObstacle.transform.SetPositionAndRotation(transform.position, Quaternion.identity);
        unPooledObstacle.gameObject.SetActive(true);
    }
}
