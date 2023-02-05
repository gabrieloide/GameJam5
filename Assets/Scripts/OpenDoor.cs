using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public bool openDoor;
    private void Update()
    {
        if (openDoor && GameManager.instance.hasKey)
        {
            Debug.Log("Change Leve");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            openDoor = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            openDoor = false;
        }
    }

}
