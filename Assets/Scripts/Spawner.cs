using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public GameObject prefab;
    // Use this for initialization
    void Start()
    {
        //spawnEnemies();
    }

    public void spawnAll()
    {
        foreach (var spawnpoint in spawnPoints)
        {
            var spawnedObject = Instantiate(prefab, spawnpoint.transform.position, spawnpoint.transform.rotation);
            if (spawnedObject.tag == "Ghost")
            {
                spawnedObject.GetComponent<Agent>().target = GameObject.FindGameObjectWithTag("Pacman").transform;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
