using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SnakeCondition : MonoBehaviour
{
    [SerializeField] private SnakeGameGrid _game;

    public UnityEvent onKilled;
    public UnityEvent onReset;

    public void KillSnake()
    {
        Debug.Log("WTF");
        onKilled?.Invoke();
    }

    public void ResetPosition()
    {
        transform.position = _game.StartPosition;
        onReset?.Invoke();
    }
}
