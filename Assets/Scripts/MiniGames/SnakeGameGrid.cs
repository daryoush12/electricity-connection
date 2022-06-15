using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeGameGrid : MiniGameBase
{
    public delegate void SnakeGameEvents();
    public SnakeGameEvents onSolved;
    public SnakeGameEvents onFail;
    public SnakeGameEvents onStart;
    public SnakeGameEvents onStop;
    public SnakeGameEvents onReset;
    

    [SerializeField] private Camera snakeCamera;
    [SerializeField] private Transform _startPoint;
    [SerializeField] private Transform _endPoint;
    [SerializeField] private GameProperties _properties;
    [SerializeField] private Snake _snake;
    [SerializeField] private GameObject _grid;

    [SerializeField] private GeneralEvent onPuzzleSolved;

    private Camera _mainCamera;
    public Vector3 StartPosition => _startPoint.position;

    private void OnEnable()
    {
        _mainCamera = Camera.main;
        snakeCamera.gameObject.SetActive(false);
    }

    private IEnumerator StartCycle()
    {
        _grid.SetActive(true);
        snakeCamera.gameObject.SetActive(true);
        _mainCamera.gameObject.SetActive(false);
        yield return new WaitForSeconds(1F);
        StartSolving();
    }

    public void StartSolving()
    {
        onStart?.Invoke();
    }

    public void StopSolving()
    {
        snakeCamera.gameObject.SetActive(false);
    }

    public void Complete()
    {
        onPuzzleCompleted?.Invoke(this);
        onPuzzleSolved.InvokeEvent();
        _properties.IncrementCompletion();
        StopMiniGame();
    }

    public override void StartMiniGame()
    {
        StartCoroutine(StartCycle());
    }

    public override void StopMiniGame()
    {
        ResetGame();
        StopSolving();
        _mainCamera.gameObject.SetActive(true);
        _grid.SetActive(false);
        onStop?.Invoke();
    }

    public override void ResetGame()
    {
        onReset?.Invoke();
    }
}
