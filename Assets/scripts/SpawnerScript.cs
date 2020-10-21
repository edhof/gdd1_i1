using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject[] enemyCats;
    public float SpawnRate;
    
    private float randX;
    private float randY;
    private Vector2 spawnPoint;
    private float nextSpawn = 0;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + SpawnRate;
            randY = Random.Range(-3, 3);
            spawnPoint = new Vector2(gameObject.transform.position.x, randY);

            var nextEnemy = Random.Range(0, enemyCats.Length);
            Instantiate(enemyCats[nextEnemy], spawnPoint, Quaternion.identity);
        }
    }
}
