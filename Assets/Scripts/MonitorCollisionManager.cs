using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonitorCollisionManager : MonoBehaviour
{
    [SerializeField] private GeneralEvent onPuzzleCompleted;
    [SerializeField] private GeneralEvent onWifiConnected;
    [SerializeField] private Collider _collider;
    [SerializeField] private ObjectHighlihter _hl;

    private void OnEnable()
    {
        onPuzzleCompleted.onEventInvoked += DisableCollision;
        onWifiConnected.onEventInvoked += EnableCollision;
    }

    private void OnDisable()
    {
        onPuzzleCompleted.onEventInvoked -= DisableCollision;
        onWifiConnected.onEventInvoked -= EnableCollision;
    }

    private void DisableCollision()
    {
        _collider.enabled = false;
        _hl.CancelHighlight();
    }

    private void EnableCollision()
    {
        _collider.enabled = true;
        _hl.CancelHighlight();
    }
}
