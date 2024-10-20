using System;
using UnityEngine;

public class PelletBehavior : MonoBehaviour
{
    float birthday;
    public float lifespan;
    Light glow;

    // Start is called before the first frame update
    void Start()
    {
        birthday = Time.time;
        lifespan = UnityEngine.Random.Range(0.25f, 0.75f);
        glow = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > birthday + lifespan)
        {
            Destroy(gameObject);
        }
        glow.intensity = Math.Max(glow.intensity - 0.5f * Time.deltaTime, 0);
    }

    void OnCollisionEnter(Collision collision)
    {
        //Destroy(gameObject,0.05f);
    }
}
