using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformScript : MonoBehaviour
{
    public float speed;
    public bool movingRight = true;
    public bool isLeftPlatform;
    void Start()
    {
        if(isLeftPlatform) transform.position = new Vector3(-6.75f, transform.position.y, 0);
        else  transform.position = new Vector3(6.75f, transform.position.y, 0);
    }

    void Update()
    {
        if (isLeftPlatform)
        {
            if (movingRight)
            {
                transform.position = new Vector3(transform.position.x + speed / 300 * GameManager.instance.generalVelocity, transform.position.y, 0);
                if (transform.position.x >= -4)
                {
                    movingRight = false;
                }
            }
            else
            {
                transform.position = new Vector3(transform.position.x - speed / 300 * GameManager.instance.generalVelocity, transform.position.y, 0);
                if (transform.position.x <= -9.4f)
                {
                    movingRight = true;
                }
            }
        }
        else
        {
            {
                if (movingRight)
                {
                    transform.position = new Vector3(transform.position.x - speed / 300 * GameManager.instance.generalVelocity, transform.position.y, 0);
                    if (transform.position.x <= 4)
                    {
                        movingRight = false;
                    }
                }
                else
                {
                    transform.position = new Vector3(transform.position.x + speed / 300 * GameManager.instance.generalVelocity, transform.position.y, 0);
                    if (transform.position.x >= 9.4f)
                    {
                        movingRight = true;
                    }
                }
            }
        }


    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        //transform.SetParent(other.transform);
    }
}
