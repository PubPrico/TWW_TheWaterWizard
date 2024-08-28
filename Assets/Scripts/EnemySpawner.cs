using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemies;

    public GameObject logo;
    public Sprite[] logoSprites;

    public GameObject[] trees;
    public Sprite[] treeSprites;

    public GameObject plane;
    public GameObject[] lanes;

    Color dayPlaneColor = new Color(0.2f, 0.5f, 0f, 1f);
    Color duskPlaneColor =  new Color(0.7f, 0.5f, 0f, 1f);
    Color nightPlaneColor = new Color(0.2f, 0.3f, 0.4f, 1f);

    Color dayLaneColor = new Color(1f, 0.8f, 0.5f, 1f);
    Color duskLaneColor = new Color(1f, 0.5f, 0.5f, 1f);
    Color nightLaneColor = new Color(0.6f, 0.5f, 0.3f, 1f);

    public float minSpawnTime, maxSpawnTime;
    int inGameMinutes;
    public TMP_Text timerText;
    float spawnTime, timer, inGameTimer;
    bool canSpawn;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        canSpawn = false;
    }

    void Update()
    {
        
        inGameTimer += Time.deltaTime;
        timerText.text = inGameTimer.ToString("F0");
        

        if(canSpawn == true)
        {
            timer += Time.deltaTime;

            if(inGameTimer > 80)
            {
                Image logoImage = logo.GetComponent<Image>();
                logoImage.sprite = logoSprites[1];

                SpriteRenderer planeGrassSpriteRenderer = plane.GetComponent<SpriteRenderer>();
                Color customColor = new Color(143, 150, 0);
                planeGrassSpriteRenderer.color = customColor;

                foreach (GameObject tree in trees)
                {
                    SpriteRenderer treeSpriteRenderer = tree.GetComponent<SpriteRenderer>();
                    treeSpriteRenderer.sprite = treeSprites[1];
                }
                if(timer >= spawnTime)
                {
                    int index = Random.Range(2, 5);
                    GameObject enemy = enemies[index];
                    Instantiate(enemy, transform.position, Quaternion.identity);

                    canSpawn = false;
                    timer = 0;
                }
            }
            else if(inGameTimer > 60)
            {
                Image logoImage = logo.GetComponent<Image>();
                logoImage.sprite = logoSprites[0];

                foreach (GameObject tree in trees)
                {
                    SpriteRenderer treeSpriteRenderer = tree.GetComponent<SpriteRenderer>();
                    treeSpriteRenderer.sprite = treeSprites[0];
                }

                if(timer >= spawnTime)
                {
                    int index = Random.Range(2, 4);
                    GameObject enemy = enemies[index];
                    Instantiate(enemy, transform.position, Quaternion.identity);

                    canSpawn = false;
                    timer = 0;
                }
            }
            else if(inGameTimer > 40)
            {
                if(timer >= spawnTime)
                {
                    Image logoImage = logo.GetComponent<Image>();
                    logoImage.sprite = logoSprites[2];

                    SpriteRenderer planeGrassSpriteRenderer = plane.GetComponent<SpriteRenderer>();
                    planeGrassSpriteRenderer.color = nightPlaneColor;
                    foreach (GameObject lane in lanes)
                    {
                        SpriteRenderer laneSpriteRenderer = lane.GetComponent<SpriteRenderer>();
                        laneSpriteRenderer.color = nightLaneColor;
                    }

                    foreach (GameObject tree in trees)
                    {
                        SpriteRenderer treeSpriteRenderer = tree.GetComponent<SpriteRenderer>();
                        treeSpriteRenderer.sprite = treeSprites[2];
                    }

                    int index = Random.Range(2, 4);
                    GameObject enemy = enemies[index];
                    Instantiate(enemy, transform.position, Quaternion.identity);

                    canSpawn = false;
                    timer = 0;
                }
            }
            else if(inGameTimer > 20)
            {
                Image logoImage = logo.GetComponent<Image>();
                logoImage.sprite = logoSprites[1];

                SpriteRenderer planeGrassSpriteRenderer = plane.GetComponent<SpriteRenderer>();
                planeGrassSpriteRenderer.color = duskPlaneColor;
                foreach (GameObject lane in lanes)
                {
                    SpriteRenderer laneSpriteRenderer = lane.GetComponent<SpriteRenderer>();
                    laneSpriteRenderer.color = duskLaneColor;
                }

                foreach (GameObject tree in trees)
                {
                    SpriteRenderer treeSpriteRenderer = tree.GetComponent<SpriteRenderer>();
                    treeSpriteRenderer.sprite = treeSprites[1];
                }

                if(timer >= spawnTime)
                {
                    int index = Random.Range(0, 4);
                    GameObject enemy = enemies[index];
                    Instantiate(enemy, transform.position, Quaternion.identity);

                    canSpawn = false;
                    timer = 0;
                }
            }
            else
            {
                Image logoImage = logo.GetComponent<Image>();
                logoImage.sprite = logoSprites[0];

                SpriteRenderer planeGrassSpriteRenderer = plane.GetComponent<SpriteRenderer>();
                planeGrassSpriteRenderer.color = dayPlaneColor;
                foreach (GameObject lane in lanes)
                {
                    SpriteRenderer laneSpriteRenderer = lane.GetComponent<SpriteRenderer>();
                    laneSpriteRenderer.color = dayLaneColor;
                }

                foreach (GameObject tree in trees)
                {
                    SpriteRenderer treeSpriteRenderer = tree.GetComponent<SpriteRenderer>();
                    treeSpriteRenderer.sprite = treeSprites[0];
                }

                if(timer >= spawnTime)
                {
                    int index = Random.Range(0, 2);
                    GameObject enemy = enemies[index];
                    Instantiate(enemy, transform.position, Quaternion.identity);

                    canSpawn = false;
                    timer = 0;
                }
            }

        }
        else
        {
            spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
            canSpawn = true;
        }
    }
}
