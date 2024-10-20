using System;
using UnityEngine;

public class PelletBehavior : MonoBehaviour
{
    public float birthday;
    public float lifespan;
    public bool collided;
    Light glow;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        birthday = Time.time;
        lifespan = UnityEngine.Random.Range(0.25f, 0.75f);
        glow = GetComponent<Light>();
        rb = GetComponent<Rigidbody>();
        collided = false;
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
        /*
        transform.Rotate(new Vector3(UnityEngine.Random.Range(-5f, 5f), UnityEngine.Random.Range(-5f, 5f), 0));
		rb.velocity = transform.forward * rb.velocity.magnitude;
        */
        //rb.velocity /= 2;
        rb.drag *= 2;
        collided = true;
    }
}
