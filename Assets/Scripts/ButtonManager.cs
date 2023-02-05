using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public int buttonCountPressed;
    [SerializeField]int AmountToOpen;
    [SerializeField] GameObject activate;
    private void Update()
    {
        ActivateDoor();
    }
    void ActivateDoor()
    {
        if (buttonCountPressed == AmountToOpen)
        {
            //Activar algo
            activate.SetActive(true);
        }
        else
        {
            activate.SetActive(false);
        }
    }
}
