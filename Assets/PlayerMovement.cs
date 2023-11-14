using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody body;
    public float velocity = 1f;
    public Transform cameraTransform;
    public float timeInterval = 2;
    private float timer = 0;
    private bool isMakingAMove = false;
    private int lockedDirection = 0; 
    private float lockedPosition = 0;

    private void Update()
    {
        // UpdateCameraPosition();

        if (!isMakingAMove)
        {
            CheckForKeyPresses();
        }
        else
        {
            if (lockedDirection == 1)
            {
                transform.position = new Vector3(lockedPosition, transform.position.y, transform.position.z);
            }
            else if (lockedDirection == 2)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, lockedPosition);
            }

            Timer();
        }
    }

    private void UpdateCameraPosition()
    {
        cameraTransform.position = new Vector3(transform.position.x, transform.position.y+10, transform.position.z);
    }

    private void CheckForKeyPresses()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            isMakingAMove = true;
            body.velocity = new Vector3(velocity,0,0);
            lockedDirection = 2;
            lockedPosition = transform.position.z;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            isMakingAMove = true;
            body.velocity = new Vector3(-velocity,0,0);
            lockedDirection = 2;
            lockedPosition = transform.position.z;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            isMakingAMove = true;
            body.velocity = new Vector3(0,0,velocity);
            lockedDirection = 1;
            lockedPosition = transform.position.x;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            isMakingAMove = true;
            body.velocity = new Vector3(0,0,-velocity);
            lockedDirection = 1;
            lockedPosition = transform.position.x;
        }
    }

    private void Timer()
    {
        if (timer < timeInterval)
            { 
                timer += Time.deltaTime; 
            } 
            else 
            {
                timer = 0;
                isMakingAMove = false;
            }
    }
}
