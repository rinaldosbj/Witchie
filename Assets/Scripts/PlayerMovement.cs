using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody body;
    public float velocity = 1f;
    public float timeInterval = 2; // -Temporary-
    private float timer = 0; // -Temporary-
    private bool isMakingAMove = false;
    private int lockedDirection = 0; // -Temporary-
    private float lockedPosition = 0; // -Temporary-
    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;
    public float swipeSensibility;

    private void Update()
    {
        if (!isMakingAMove)
        {
            CheckForSwipe();
            CheckForKeyPresses(); // For testing purposes -Temporary-
        }
        else
        {
            if (lockedDirection == 1) // Locked X -Temporary-
            {
                transform.position = new Vector3(lockedPosition, transform.position.y, transform.position.z);
            }
            else if (lockedDirection == 2) // Locked Z -Temporary-
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, lockedPosition);
            }

            // Will be substituted for collision on the wall -Temporary-
            Timer();
        }
    }

    private void CheckForSwipe()
    {
        if (Input.touchCount > 0 && Input. GetTouch (0).phase == TouchPhase.Began)
            {
                startTouchPosition = Input.GetTouch(0).position;
            }
            if (Input.touchCount > 0 && Input. GetTouch (0).phase == TouchPhase.Ended)
            {
                endTouchPosition = Input.GetTouch(0).position;

                float deltaX = endTouchPosition.x - startTouchPosition.x;
                float deltaY = endTouchPosition.y - startTouchPosition.y;

                if (Math.Abs(deltaX) > Math.Abs(deltaY))
                {
                    if (deltaX > swipeSensibility)
                    {
                        moveRight();
                    }
                    else if (deltaX < -swipeSensibility)
                    {
                        moveLeft();
                    }
                }
                else
                {
                    if (deltaY > swipeSensibility)
                    {
                        moveUp();
                    }
                    else if (deltaY < -swipeSensibility)
                    {
                        moveDown();
                    }
                }
            }
    }

    private void CheckForKeyPresses()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            moveRight();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            moveLeft();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            moveUp();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            moveDown();
        }
    }

    private void moveRight()
    {
        isMakingAMove = true;
        body.velocity = new Vector3(velocity,0,0);
        lockedDirection = 2;
        lockedPosition = transform.position.z;
    }
    private void moveLeft()
    {
        isMakingAMove = true;
        body.velocity = new Vector3(-velocity,0,0);
        lockedDirection = 2;
        lockedPosition = transform.position.z;
    }
    private void moveUp()
    {
        isMakingAMove = true;
        body.velocity = new Vector3(0,0,velocity);
        lockedDirection = 1;
        lockedPosition = transform.position.x;
    }
    private void moveDown()
    {
        isMakingAMove = true;
        body.velocity = new Vector3(0,0,-velocity);
        lockedDirection = 1;
        lockedPosition = transform.position.x;
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
