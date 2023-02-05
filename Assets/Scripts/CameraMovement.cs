using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject PlayerPosition;

    public float time;
    private void Start()
    {
        PlayerPosition = GameObject.Find("PlayerDad");
    }
    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, GameManager.instance.currentPlayer.transform.position, time * Time.deltaTime);
    }
}
