using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemies;
    float spawnTime, timer;
    bool canSpawn;
    // Start is called before the first frame update
    void Start()
    {
        canSpawn = false;
    }

    // Update is called once per frame
    void Update()
    {

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
            spawnTime = Random.Range(4, 10);
            canSpawn = true;
        }
    }
}
