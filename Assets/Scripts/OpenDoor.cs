using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenDoor : MonoBehaviour
{
    public bool openDoor;
    public string NextLevel;
    private void Update()
    {
        if (openDoor && GameManager.instance.hasKey)
        {
            SceneManager.LoadScene(NextLevel);
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
