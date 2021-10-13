using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemyTypes;
    public List<GameObject> enemies;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 100; i++)
        {
            //Debug.Log((i = 1).ToString());
        }

       /* if (Input.GetKeyDown("I"))
        {
            SpawnEnemy();
        }*/
        SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.I))
        {
            SpawnEnemy();
        }*/
    }

    [ContextMenu("Spawn Enemy")]
    public void SpawnEnemy()
    {
        for (int index = 0; index < enemyTypes.Length; index++)
        {
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            GameObject newSpawn = Instantiate(enemyTypes[index], spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation);
            enemies.Add(newSpawn);
            Debug.Log(enemies.Count);
        }

        Debug.Log("Total: " + enemies.Count + "enemies");
    }
}
