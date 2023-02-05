using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [HideInInspector]public int buttonCountPressed;
    [SerializeField]int AmountToOpen;

    void ActivateDoor()
    {
        if (buttonCountPressed == AmountToOpen)
        {
            //Activar algo
            Debug.Log("Abriendo puerta");
        }
    }
}
