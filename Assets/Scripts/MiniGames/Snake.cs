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
    [Range(0f, 5F)]
    [SerializeField] private float _speecModifier;
    [SerializeField] private Rigidbody2D _rb;

    private Vector2 _diff;
    private bool shouldMove;
    private Vector3 _original;

    public Vector3 CurrentDirection => _dir;

    private void Awake()
    {
        //Set direction to 0,0
        _original = transform.position;
        _dir = Vector2.right;
        shouldMove = false;
    }

    private void OnEnable()
    {
        _game.onStart += StartMovingSnake;
        _game.onStop += StopSnake;
        _game.onReset += ResetSnake;
        _game.onSolved += StopSnake;
    }

    private void OnDisable()
    {
        _game.onStart -= StartMovingSnake;
        _game.onStop -= StopSnake;
        _game.onReset -= ResetSnake;
        _game.onSolved -= StopSnake;
    }

    private void MoveSnake()
    {
        if (shouldMove)
            _rb.velocity = _dir * _speecModifier;
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

        //Snake head can move into given direction only if body is not there.
        MoveSnake();
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
        _dir = Vector2.right;
        shouldMove = true;
        _snakeInput.ActivateInput();
        //Snake head can move into given direction only if body is not there.
        MoveSnake();
    }

    public void ResetSnake()
    {
        gameObject.SendMessage("SetActive");
        gameObject.SendMessage("ResetPosition");
        _dir = Vector2.right;
        //StartMovingSnake();
    }
}
