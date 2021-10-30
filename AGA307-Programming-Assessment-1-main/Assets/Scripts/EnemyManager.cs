using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : Singleton<EnemyManager>
{
    public Transform[] spawnPoints;
    public GameObject[] enemyTypes;
    public List<GameObject> enemies;

    float spawnDelay = 5f;

    private void OnEnable()
    {
        GameEvents.OnEnemyDied += EnemyDied;
    }

    private void OnDisable()
    {
        GameEvents.OnEnemyDied -= EnemyDied;
    }

    public void EnemyDied(Enemies toRemove)
    {
        enemies.Remove(toRemove.gameObject);
        //Destroy(toRemove.gameObject);
        Debug.Log("Total: " + enemies.Count + " enemies");
    }

    // Start is called before the first frame update
    void Start()
    {
        /*for (int i = 0; i < 100; i++)
        {
            Debug.Log((i = 1).ToString());
        }*/
        SpawnEnemy();
        StartCoroutine(DelayedSpawn(enemies.Count));
        //ShuffleList(enemies);

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    [ContextMenu("Spawn Enemy")]
    public void SpawnEnemy()
    {
        for (int index = 0; index < enemyTypes.Length; index++)
        {
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            GameObject newSpawn = Instantiate(enemyTypes[index], spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation);
            enemies.Add(newSpawn);
            //Debug.Log(enemies.Count);
        }

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

    /*public void EnemyDied(Enemies _enemy)
    {
        enemies.Remove(_enemy.gameObject);
        Debug.Log(enemies.Count);
    }*/
}
