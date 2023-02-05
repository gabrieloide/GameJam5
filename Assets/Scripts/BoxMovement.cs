using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMovement : MonoBehaviour
{
    public Transform newParent;
    public void MoveBox(Transform playerParent)
    {
        transform.SetParent(playerParent);
        if (FindObjectOfType<PlayerController>().canMoveBox == false)
        {
            transform.SetParent(newParent);

        }
    }
}
