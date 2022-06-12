using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeGameGrid : MonoBehaviour
{
    public delegate void SnakeGameEvents();
    public SnakeGameEvents onSolved;
    public SnakeGameEvents onFail;
    public SnakeGameEvents onStart;

    [SerializeField] private Camera snakeCamera;

    public void StartSolving()
    {
        onStart?.Invoke();
        snakeCamera.gameObject.SetActive(true);
    }
}
