using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateKey : MonoBehaviour
{
    public bool canGiveKey;
    private void Update()
    {
        if (canGiveKey && Input.GetKeyDown(KeyCode.J))
        {
            GameManager.instance.hasKey = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canGiveKey = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        canGiveKey = false;
    }
}
