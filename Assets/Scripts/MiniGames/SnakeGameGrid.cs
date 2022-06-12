using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeGameGrid : MonoBehaviour
{
    public delegate void SnakeGameEvents();
    public SnakeGameEvents onSolved;
    public SnakeGameEvents onFail;
    public SnakeGameEvents onStart;
    public SnakeGameEvents onStop;

    [SerializeField] private Camera snakeCamera;
    [SerializeField] private Transform _startPoint;
    [SerializeField] private Transform _endPoint;

    public Vector3 StartPosition => _startPoint.position;

    public void StartSolving()
    {
        snakeCamera.gameObject.SetActive(true);
        onStart?.Invoke();
    }

    public void StopSolving()
    {
        snakeCamera.gameObject.SetActive(false);
    }
}
