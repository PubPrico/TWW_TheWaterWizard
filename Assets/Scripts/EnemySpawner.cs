using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemies;
    public float minSpawnTime, maxSpawnTime, inGameTimer;
    int inGameMinutes;
    public TMP_Text timerText;
    float spawnTime, timer;
    bool canSpawn;
    // Start is called before the first frame update
    void Start()
    {
        canSpawn = false;
    }

    void Update()
    {

        if(inGameTimer >= 60)
        {
            inGameTimer -= 60;
            inGameMinutes++;
        }
        if(inGameTimer <= 9)
        {
            inGameTimer -= Time.deltaTime;
            timerText.text = inGameMinutes.ToString() + ":0" + inGameTimer.ToString("F0");
        }
        else
        {
            inGameTimer -= Time.deltaTime;
            timerText.text = inGameMinutes.ToString() + ":" + inGameTimer.ToString("F0");
        }

        if(canSpawn == true)
        {
            timer += Time.deltaTime;

            if(timer >= spawnTime)
            {
                int index = Random.Range(0, enemies.Length);
                GameObject enemy = enemies[index];
                Instantiate(enemy, transform.position, Quaternion.identity);

                canSpawn = false;
                timer = 0;
            }

        }
        else
        {
            spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
            canSpawn = true;
        }
    }
}
