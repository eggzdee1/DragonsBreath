using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
	public GameObject pellet;
	public float velocity;
	float lastFire;
	public float firePeriod;

	// Start is called before the first frame update
	void Start()
	{
		lastFire = Time.time;
		//fire();
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButtonDown(0) && Time.time > lastFire + firePeriod)
		{
			lastFire = Time.time;
			fire();
		}
	}

	void fire()
	{
		for (int i = 0; i < 9; i++)
		{
            GameObject p = Instantiate(pellet, transform.position, transform.rotation);
            p.transform.position += p.transform.forward * (transform.localScale.z / 2 + 0.5f);
			p.transform.Rotate(new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0));
			p.GetComponent<Rigidbody>().velocity = p.transform.forward * velocity;
        }
	}
}
