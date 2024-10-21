using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotater : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        //mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.nearClipPlane));
        mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, transform.position.y));
        Vector3 direction = mousePosition - transform.position;
        float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, angle, 0));
    }
}
