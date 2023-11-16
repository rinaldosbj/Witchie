using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaldeiraoCheck : MonoBehaviour
{
    public GameObject caldeirao;
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
                    gameObject.SetActive(false);
                    Debug.Log("Colocou caldeirao na runa");
                }
                count --;
            }
            countCaldeirao--;
        }
    }
}
