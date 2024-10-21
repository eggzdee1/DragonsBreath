using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
	private float lastFire;

	[SerializeField] private GameObject pellet;
	[SerializeField] private float velocity;
	[SerializeField] private float firePeriod;
    [SerializeField] private float dmg;
    [SerializeField] private float spread;
    [SerializeField] private float pellets;

	// Start is called before the first frame update
	void Start()
	{
		lastFire = -100;
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	public void fire()
	{
        if (Time.time > lastFire + firePeriod)
        {
            lastFire = Time.time;
            for (int i = 0; i < pellets; i++)
            {
                GameObject p = Instantiate(pellet, transform.position, transform.rotation);
                p.transform.position += p.transform.forward * (transform.localScale.z / 2 + 0.5f);
                p.transform.Rotate(new Vector3(Random.Range(-spread, spread), Random.Range(-spread, spread), 0));
                p.GetComponent<Rigidbody>().velocity = p.transform.forward * velocity;
                p.GetComponent<PelletBehavior>().dmg = dmg;
            }
        }
	}
}
