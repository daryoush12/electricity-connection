using Knife.PostProcessing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectHighlihter : MonoBehaviour
{
    public UnityEvent onHighlight;
    public UnityEvent onCancel;

    public OutlineRegister _r;

    public void HighlightObject()
    {
        _r.enabled = true;
        onHighlight?.Invoke();
    }

    public void CancelHighlight()
    {
        _r.enabled = false;
        onCancel?.Invoke();
    }
}
