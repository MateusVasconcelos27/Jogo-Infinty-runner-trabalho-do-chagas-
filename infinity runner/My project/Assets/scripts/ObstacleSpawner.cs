using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
   public GameObject obstaclePrefab;
   public float spawnRate = 2f;
   public float spawnYPosition = 0f;
   public float minSpeed = 3f;

   public float maxSpeed = 7f;

   public float timer;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > spawnRate)
        {
            SpawnObstacle();
            timer = 0;
        }
    }
    void SpawnObstacle()
    {
        Vector3 spawnPosition = new Vector3(10f, spawnYPosition, 0);

        GameObject newObstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);

        float randomSpeed = Random.Range(minSpeed, maxSpeed);
        newObstacle.GetComponent<Obstacle>().speed = randomSpeed;
    }
}
