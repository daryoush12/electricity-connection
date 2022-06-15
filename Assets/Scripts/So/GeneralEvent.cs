using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Events/GeneralEvent")]
public class GeneralEvent : ScriptableObject
{
    public delegate void GeneralEventDelegate();
    public GeneralEventDelegate onEventInvoked;

    public void InvokeEvent()
    {
        onEventInvoked?.Invoke();
    }
}