using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    public AK.Wwise.Event AudioEvent;

    public void TriggerFEvent()
    {
        AudioEvent.Post(gameObject);
    }
}
