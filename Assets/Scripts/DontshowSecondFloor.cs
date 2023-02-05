using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontshowSecondFloor : MonoBehaviour
{
    public GameObject DontShowSecondFloor;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DontShowSecondFloor.SetActive(false);
        }
    }
}
