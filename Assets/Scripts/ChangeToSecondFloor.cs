using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeToSecondFloor : MonoBehaviour
{
    [SerializeField] GameObject SecondFloor;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SecondFloor.SetActive(true);
        }
    }
}
