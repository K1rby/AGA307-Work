using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemyTypes;
    public List<GameObject> enemies;

    float spawnDelay = 5f;

    // Start is called before the first frame update
    void Start()
    {
        /*for (int i = 0; i < 100; i++)
        {
            Debug.Log((i = 1).ToString());
        }*/
        SpawnEnemy();
        StartCoroutine(DelayedSpawn(enemies.Count));

    }

    // Update is called once per frame
    void Update()
    {
        //PLACE THIS STATEMENT IN TARGET SCRIPT
        /*if (Input.GetKeyDown(KeyCode.I))
        {
            SpawnTargets();
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

        /*int spawnIndex = Random.Range(0, spawnPoints.Length);
        int enemyIndex = Random.Range(0, enemyTypes.Length);
        GameObject newSpawn = Instantiate(enemyTypes[enemyIndex], spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation);
        enemies.Add(newSpawn);
        Debug.Log(enemies.Count);*/

        Debug.Log("Total: " + enemies.Count + " enemies");
    }

    IEnumerator DelayedSpawn(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
