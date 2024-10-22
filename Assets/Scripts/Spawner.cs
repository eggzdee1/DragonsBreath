using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject otherSpawner;
    private Spawner otherSpawnerScript;
    [SerializeField] private GameObject jw;
    [SerializeField] private float spawnPeriod;
    public float lastSpawn;
    [SerializeField] private GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        otherSpawnerScript = otherSpawner.GetComponent<Spawner>();        
        lastSpawn = -100;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > Mathf.Max(lastSpawn, otherSpawnerScript.lastSpawn) + spawnPeriod && Vector3.Distance(transform.position, jw.transform.position) > Vector3.Distance(otherSpawner.transform.position, jw.transform.position))
        {
            lastSpawn = Time.time;
            GameObject e = Instantiate(enemy, transform.position, transform.rotation);
            e.GetComponent<EnemyController>().jw = jw;
        }
    }
}
