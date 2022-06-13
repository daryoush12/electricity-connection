using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePointer : MonoBehaviour
{
    [SerializeField] private MiniGameBase _puzzle;

    public void OpenPuzzle()
    {
        Debug.Log("Invoke puzzle");
        _puzzle.StartMiniGame();
    }

    public void ClosePuzzle()
    {
        _puzzle.StopMiniGame();
    }
}
