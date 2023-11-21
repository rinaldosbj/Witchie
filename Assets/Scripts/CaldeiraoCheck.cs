using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaldeiraoCheck : MonoBehaviour
{
    public GameLogicScript gameLogic;
    public GameObject caldeirao;

    private void Start()
    {
        gameLogic = FindObjectOfType<GameLogicScript>();
    }

    private void Update() {
        int countCaldeirao = caldeirao.transform.childCount - 1;
        int count = transform.childCount - 1;
        
        while (countCaldeirao >= 0)
        {
            count = transform.childCount - 1;
            

            while (count >= 0) 
            {
                if (caldeirao.transform.GetChild(countCaldeirao).position == transform.GetChild(count).position)
                {
                    Destroy(transform.GetChild(count).gameObject);
                    Debug.Log("Colocou caldeirao na runa");
                    if (countCaldeirao == 0) {
                        gameLogic.nextLevel();
                    }
                }
                count --;
            }
            countCaldeirao--;
        }
    }
}
