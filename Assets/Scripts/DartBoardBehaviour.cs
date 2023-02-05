using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartBoardBehaviour : MonoBehaviour
{
    public GameObject Activate;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Activate.SetActive(false);
        }
    }
}
