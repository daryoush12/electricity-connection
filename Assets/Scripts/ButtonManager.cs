using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonManager : MonoBehaviour
{
    public UnityEvent onButtonPushed;

    public void OpenPuzzle()
    {
        onButtonPushed.Invoke();
    }
}
