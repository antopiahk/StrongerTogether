using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraMovement : MonoBehaviour
{

    public float interpVelocity;
    public float followDistance;
    public float speed;
    public GameObject target;
    public Vector3 offset;
    public float waitTime;
    void Start()
    {
    }

    void FixedUpdate()
    {

        if (Time.timeSinceLevelLoad > waitTime) // Check if target (Player) is alive
        {
            transform.position = new Vector3(0, transform.position.y + speed*GameManager.instance.generalVelocity / 100, -10);
        }
    }
}
