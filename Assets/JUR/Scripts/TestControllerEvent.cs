using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestControllerEvent : MonoBehaviour
{
    public string str_event;

    public void OnSelect(string _eventName)
    {

        Debug.Log(str_event);
    }
}
