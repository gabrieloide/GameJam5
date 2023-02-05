using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartBoardBehaviour : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("Hola");
        }
    }
}
