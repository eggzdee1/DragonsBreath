using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private float armor;
    [SerializeField] private GameObject jw;
    [SerializeField] private float detectionRadius;
    [SerializeField] private float reactionTime;
    [SerializeField] private float rotationVelocity;
    [SerializeField] private NavMeshAgent agent;
    private int detectionState;
    private float lastDetection;
    
    // Start is called before the first frame update
    void Start()
    {
        detectionState = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Detection states
        bool los = LOS();
        if (los && detectionState == 0)
        {
            detectionState = 1;
            lastDetection = Time.time;
        }
        if (!los)
        {
            detectionState = 0;
        }
        if (detectionState == 1 && Time.time > lastDetection + reactionTime)
        {
            detectionState = 2;
        }

        //If detected, turn to the player and start blasting
        if (detectionState == 2)
        {
            Vector3 direction = jw.transform.position - transform.position;
            direction.y = 0;
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            if (Quaternion.Angle(transform.rotation, targetRotation) < 0.1f)
            {
                Gun gun = GetComponentInChildren<Gun>();
                gun.fire();
            }
            else 
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationVelocity * Time.deltaTime);
            }
            agent.SetDestination(transform.position);
        }
        else agent.SetDestination(jw.transform.position);
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg / (1 + armor);
        if (health <= 0) Destroy(gameObject);
    }

    bool LOS()
    {
        if (Vector3.Distance(transform.position, jw.transform.position) >= detectionRadius) return false;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, jw.transform.position - transform.position, out hit))
        {
            // Check if the ray hit something other than the target
            if (hit.transform.position != jw.transform.position)
            {
                return false; // There is an obstacle
            }
        }
        return true; // No obstacles in the way
    }
}
