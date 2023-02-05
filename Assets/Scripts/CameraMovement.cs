using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject PlayerPosition;

    public float time;
    private void Start()
    {
        PlayerPosition = GameObject.Find("CameraPosition");
    }
    private void FixedUpdate()
    {
        transform.SetParent(PlayerPosition.transform);
        if (FindObjectOfType<PlayerController>().moveInput.x > 0)
        {
            transform.localScale = new Vector3(-1,1,1);
        }
        
    }
}
