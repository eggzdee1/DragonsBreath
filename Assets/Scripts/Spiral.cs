using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spiral : MonoBehaviour
{
    Rigidbody rb;
    float rotationSpeed;
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        speed = 10;
        rotationSpeed = 360;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        speed += Time.deltaTime * 5;
        rb.velocity = transform.forward * speed;
    }
}
