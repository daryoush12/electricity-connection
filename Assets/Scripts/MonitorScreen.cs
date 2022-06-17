using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MonitorScreen : MonoBehaviour
{
    [SerializeField] private GeneralEvent onWifiConnected;
    [SerializeField] private GeneralEvent onWifiDisconnected;
    [SerializeField] private TextMeshProUGUI _output;

    private void OnEnable()
    {
        onWifiConnected.onEventInvoked += DisplayConnected;
        onWifiDisconnected.onEventInvoked += DisplayDisconnected;
    }

    private void OnDisable()
    {
        onWifiConnected.onEventInvoked -= DisplayConnected;
        onWifiDisconnected.onEventInvoked -= DisplayDisconnected;
    }

    private void Start()
    {
        DisplayDisconnected();
    }

    public void DisplayConnected()
    {
        _output.text = "Connected";
    }

    public void DisplayDisconnected()
    {
        _output.text = "Disconnected";
    }

}
