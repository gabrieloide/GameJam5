using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float time;
    public void CameraM(Transform Pos)
    {
        Vector3 offset = new Vector3(0, 6, -5.84f);
        transform.position = Vector3.Lerp(transform.position, Pos.position + offset, time * Time.deltaTime);
    }
}
