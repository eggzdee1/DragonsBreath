using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] spawners;
    [SerializeField] private GameObject jw;
    [SerializeField] private float initialSpawnPeriod;
    [SerializeField] private float maxSpawnPeriod;
    private float spawnPeriod;
    private float lastSpawn;
    [SerializeField] private GameObject[] enemies;
    System.Random rand;
    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
        lastSpawn = -100;
        rand = new System.Random();
        spawnPeriod = initialSpawnPeriod;
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > lastSpawn + spawnPeriod)
        {
            lastSpawn = Time.time;
            if (spawnPeriod > maxSpawnPeriod) spawnPeriod = initialSpawnPeriod - (Time.time - startTime) / 30;

            List<GameObject> farSpawners = new List<GameObject>();
            foreach (GameObject s in spawners)
            {   
                //Debug.Log(Vector3.Distance(s.transform.position, jw.transform.position));
                if (Vector3.Distance(s.transform.position, jw.transform.position) > 10) farSpawners.Add(s);
            }

            GameObject randSpawner = farSpawners[rand.Next(0, farSpawners.Count)];

            GameObject enemy = enemies[rand.Next(0, enemies.Length)];
            GameObject e = Instantiate(enemy, randSpawner.transform.position, randSpawner.transform.rotation);

            e.transform.position += new Vector3(Random.Range(-0.1f, 0.1f), 0, Random.Range(-0.1f, 0.1f));
            e.transform.Rotate(new Vector3(0, Random.Range(0, 360), 0));

            EnemyController eScript = e.GetComponent<EnemyController>();

            eScript.jw = jw;

            int seeking = rand.Next(0, 5);
            if (seeking > 0) eScript.seeking = true;
            else eScript.seeking = false;
        }
    }
}
