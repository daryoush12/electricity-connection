using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MiniGameBase : MonoBehaviour
{
    public delegate void MiniGameBaseEvents(MiniGameBase b);
    public static MiniGameBaseEvents onPuzzleCompleted;

    public abstract void StartMiniGame();

    public abstract void StopMiniGame();

    public abstract void ResetGame();
}
