using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;


public class Snake : MonoBehaviour 
{
    //Direction of the snake movement
    [SerializeField] private Vector3 _dir;

    // Main game grid
    [SerializeField] private SnakeGameGrid _game;
    [SerializeField] private PlayerInput _snakeInput;

    private Vector2 _diff;
    private bool shouldMove;

    public Vector3 CurrentDirection => _dir;

    private void Awake()
    {
         //Set direction to 0,0
        _dir = Vector2.right;
        shouldMove = true;
    }

    private void OnEnable()
    {
        _game.onStart += StartMovingSnake;
    }

    private void OnDisable()
    {
        _game.onStart -= StartMovingSnake;
    }

    private void FixedUpdate()
    {
        //Snake head can move into given direction only if body is not there.
        MoveSnake();
        
    }

    private void MoveSnake()
    {
        transform.position += _dir * Time.deltaTime;
    }

    public void ReadMovementInput(CallbackContext context)
    {
        if (context.performed || context.canceled || !shouldMove) return;

        var newDir = context.ReadValue<Vector2>();
        if (newDir.x == -1 && _dir.x == 1) return;
        else if (newDir.x == 1 && _dir.x == -1) return;
        else if (newDir.y == -1 && _dir.y == 1) return;
        else if (newDir.y == 1 && _dir.y == -1) return;


        _dir = newDir;
        Debug.Log($"Direction: {_dir}");
    }

    public void StopSnake()
    {
        _dir = Vector2.zero;
        shouldMove = false;
        _snakeInput.DeactivateInput();
    }

    public void StartMovingSnake()
    {
        shouldMove = true;
        _snakeInput.ActivateInput();
    }

    public void ResetSnake()
    {
        gameObject.SendMessage("SetActive");
        gameObject.SendMessage("ResetPosition");

        StartMovingSnake();
    }
}
