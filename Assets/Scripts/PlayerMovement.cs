using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool isMakingAMove = false;
    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;
    public float swipeSensibility;
    public GameObject paredes;
    public GameObject caldeiroes;
    public GameObject runas;
    private enum Directions { Right, Left, Up, Down }
    private Directions moveDirection;
    private bool isFirstMicroMove;

    private void Update()
    {
        if (!isMakingAMove)
        {
            CheckForSwipe();
            isFirstMicroMove = true;
        }
        else
        {
            switch (moveDirection)
            {
                case Directions.Right:
                    Move(new Vector3(transform.position.x + 1, transform.position.y, transform.position.z));
                    break;
                case Directions.Left:
                    Move(new Vector3(transform.position.x - 1, transform.position.y, transform.position.z));
                    break;
                case Directions.Up:
                    Move(new Vector3(transform.position.x, transform.position.y, transform.position.z + 1));
                    break;
                case Directions.Down:
                    Move(new Vector3(transform.position.x, transform.position.y, transform.position.z - 1));
                    break;
            }
        }
    }

    private void CheckForSwipe()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPosition = Input.GetTouch(0).position;

            float deltaX = endTouchPosition.x - startTouchPosition.x;
            float deltaY = endTouchPosition.y - startTouchPosition.y;

            if (Math.Abs(deltaX) > Math.Abs(deltaY))
            {
                if (deltaX > swipeSensibility)
                {
                    isMakingAMove = true;
                    moveDirection = Directions.Right;
                }
                else if (deltaX < -swipeSensibility)
                {
                    isMakingAMove = true;
                    moveDirection = Directions.Left;
                }
            }
            else
            {
                if (deltaY > swipeSensibility)
                {
                    isMakingAMove = true;
                    moveDirection = Directions.Up;
                }
                else if (deltaY < -swipeSensibility)
                {
                    isMakingAMove = true;
                    moveDirection = Directions.Down;
                }
            }
        }
    }


    private void Move(Vector3 direcao)
    {
        int countParede = paredes.transform.childCount - 1;
        int countCaldeirao = caldeiroes.transform.childCount - 1;
        int countRunas = runas.transform.childCount - 1;

        bool isWall = false;

        while (countParede >= 0)
        {
            if (paredes.transform.GetChild(countParede).position == new Vector3(direcao.x, 1, direcao.z))
            {
                isWall = true;
                isMakingAMove = false;
            }
            countParede--;
        }
        while (countRunas >= 0)
        {
            if (runas.transform.GetChild(countRunas).position == new Vector3(direcao.x, 1, direcao.z))
            {
                isWall = true;
                isMakingAMove = false;
            }
            countRunas--;
        }
        while (countCaldeirao >= 0)
        {
            if (caldeiroes.transform.GetChild(countCaldeirao).position == new Vector3(direcao.x, 1, direcao.z))
            {
                isWall = true;
                isMakingAMove = false;
                if (isFirstMicroMove)
                {
                    countParede = paredes.transform.childCount - 1;
                    Vector3 boxDirection = new Vector3(direcao.x, 1, direcao.z);
                    switch (moveDirection)
                        {
                            case Directions.Right:
                                boxDirection = new Vector3(direcao.x + 1, 1, direcao.z);
                                break;
                            case Directions.Left:
                                boxDirection = new Vector3(direcao.x - 1, 1, direcao.z);
                                break;
                            case Directions.Up:
                                boxDirection = new Vector3(direcao.x, 1, direcao.z + 1);
                                break;
                            case Directions.Down:
                                boxDirection = new Vector3(direcao.x, 1, direcao.z - 1);
                                break;
                        }
                    bool boxIsNearTheWall = false;
                    while (countParede >= 0)
                    {
                        if (paredes.transform.GetChild(countParede).position == boxDirection)
                        {
                            boxIsNearTheWall = true;
                        }
                        countParede--;
                    }
                    if (!boxIsNearTheWall)
                    {
                        caldeiroes.transform.GetChild(countCaldeirao).position = boxDirection;
                        transform.position = direcao;
                    }
                }
            }
            countCaldeirao--;
        }
        if (!isWall)
        {
            isFirstMicroMove = false;
            transform.position = direcao;
        }
    }
}
