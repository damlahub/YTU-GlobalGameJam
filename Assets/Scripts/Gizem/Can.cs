using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Can : MonoBehaviour
{
    public int can = 3;
    private void Update()
    {
        switch (can)
        {
            case 0:
                gameObject.transform.GetChild(2).gameObject.SetActive(false);
                break;

            case 1:
                gameObject.transform.GetChild(1).gameObject.SetActive(false);
                break;

            case 2:
                gameObject.transform.GetChild(0).gameObject.SetActive(false);
                break;
            default:
                break;
        }
    }
}
