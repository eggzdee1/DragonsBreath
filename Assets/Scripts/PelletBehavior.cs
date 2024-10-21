using System;
using UnityEngine;

public class PelletBehavior : MonoBehaviour
{
    private float birthday;
    private float lifespan;
    private bool collided;
    private Light glow;
    private Rigidbody rb;
    public float dmg;

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
        EnemyController e = collision.gameObject.GetComponent<EnemyController>();
        PlayerController p = collision.gameObject.GetComponent<PlayerController>();
        if (!collided)
        {
            if (e != null) e.TakeDamage(dmg);
            if (p != null) p.TakeDamage(dmg);
        }

        rb.drag *= 2;
        collided = true;
    }
}
