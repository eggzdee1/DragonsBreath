using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float maxSpeed;
    public float forceMultiplier;
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
    }

    void FixedUpdate()
    {
        rb.AddForce(force.normalized * forceMultiplier, ForceMode.Impulse);
    }
}
