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
    Vector3 targetPos;
    void Start()
    {
        targetPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.time >= 5) // Check if target (Player) is alive
        {
            Vector3 posZ = transform.position; // Z offset
            posZ.z = target.transform.position.z;

            Vector3 targetDirection = Vector2.up; // Make sure the camera stays infront of the object;

            interpVelocity = targetDirection.magnitude * speed; // Speeeed

            targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime); // Math stuff

            transform.position = Vector3.Lerp(transform.position, targetPos + offset, 0.25f); // Lerp from camera's current position to the target's position.

        }
    }
}
