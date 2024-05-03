using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject enemyPre;
    public bool enableSpawn = false;
    private int enemyCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 3, 2);
    }

    // Update is called once per frame
    void SpawnEnemy()
    {
        if (enableSpawn && enemyCount < 20)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-30.0f, 20.0f), 0.0f, Random.Range(-20f, 10f));
            Instantiate(enemyPre, spawnPos, Quaternion.identity);
            enemyCount++;

            float interval = 2.0f;
            if (Time.time > 10.0f) interval = 1.0f;
            if (Time.time > 20.0f) interval = 0.5f;

            if (enemyCount >= 15)
            {
                enableSpawn = false;
            }
        }
    }
}
