using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroySnake : MonoBehaviour
{
    public GameObject snake;
    public GameObject chest;
    private void OnEnable()
    {
        Destroy(snake);
        chest.SetActive(true);
    }
}
