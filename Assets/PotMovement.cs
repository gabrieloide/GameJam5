using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotMovement : MonoBehaviour
{
    public Transform newParent;
    public void Pot(Transform playerParent, Vector3 potOnHead)
    {
        transform.SetParent(playerParent);
        transform.position = potOnHead;
        if (FindObjectOfType<PlayerController>().takePot == false)
        {
            transform.SetParent(newParent);

        }
    }
}
