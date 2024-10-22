using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private float armor;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float forceMultiplier;
    private Vector3 force;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        force.x = Input.GetAxisRaw("Horizontal") * Mathf.Max(maxSpeed - rb.velocity.magnitude, 0);
        force.z = Input.GetAxisRaw("Vertical") * Mathf.Max(maxSpeed - rb.velocity.magnitude, 0);

        if (Input.GetMouseButtonDown(0))
		{
            Gun gun = GetComponentInChildren<Gun>();
			gun.fire();
		}
    }

    void FixedUpdate()
    {
        rb.AddForce(force.normalized * forceMultiplier, ForceMode.Impulse);
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg / (1 + armor);
        if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
