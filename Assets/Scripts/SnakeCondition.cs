using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SnakeCondition : MonoBehaviour
{

    public UnityEvent onKilled;

    public void KillSnake()
    {
        Debug.Log("WTF");
        onKilled?.Invoke();
    }
}
