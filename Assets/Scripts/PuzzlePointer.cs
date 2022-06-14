using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PuzzlePointer : MonoBehaviour
{
    [SerializeField] private MiniGameBase _puzzle;

    public UnityEvent onInteraction;

    public void OpenPuzzle()
    {
        Debug.Log("Invoke puzzle");
        onInteraction?.Invoke();
        _puzzle.StartMiniGame();
    }

    public void ClosePuzzle()
    {
        _puzzle.StopMiniGame();
    }
}
