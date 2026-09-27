using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnemySpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject asteroidPrefab;
    public float spawnRatePerMinute = 30;
    public float spawnRateIncrement = 1;
    public float xBorderLimit, yBorderLimit;
    private float spawnNext = 0; 
    public float MaxTimeFile = 4f; 

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= spawnNext)
        {
            spawnNext = Time.time + 60 / spawnRatePerMinute;
            spawnRatePerMinute += spawnRateIncrement;
            var rand = Random.Range(-xBorderLimit, xBorderLimit);
            var spawnPosition = new Vector2(rand, yBorderLimit);
            GameObject metor = Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);
            Destroy(metor, MaxTimeFile);
        }
    }
}
