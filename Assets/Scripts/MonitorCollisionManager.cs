using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonitorCollisionManager : MonoBehaviour
{
    [SerializeField] private GeneralEvent onPuzzleCompleted;
    [SerializeField] private Collider _collider;
    [SerializeField] private ObjectHighlihter _hl;

    private void OnEnable()
    {
        onPuzzleCompleted.onEventInvoked += DisableCollision;
    }

    private void OnDisable()
    {
        onPuzzleCompleted.onEventInvoked -= DisableCollision;
    }

    private void DisableCollision()
    {
        _collider.enabled = false;
        _hl.CancelHighlight();
    }
}
