using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Target_Manager : Singleton<Target_Manager>
{
    public Transform[] targetSpawnPoints;
    public GameObject[] targetTypes;
    public List<GameObject> targets;

    public void TargetDestroyed(Target toRemove)
    {
        targets.Remove(toRemove.gameObject);
        //Destroy(toRemove.gameObject);
        Debug.Log("Total: " + targets.Count + " targets");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            SpawnTarget();
        }
    }

    [ContextMenu("Spawn Target")]
    public void SpawnTarget()
    {
        int targetSpawnIndex = Random.Range(0, targetSpawnPoints.Length);
        int targetIndex = Random.Range(0, targetTypes.Length);
        GameObject newSpawn = Instantiate(targetTypes[targetIndex], targetSpawnPoints[targetSpawnIndex].position, targetSpawnPoints[targetSpawnIndex].rotation);
        targets.Add(newSpawn);
        Debug.Log(targets.Count);

        Debug.Log("Total: " + targets.Count + " targets");
    }
}
