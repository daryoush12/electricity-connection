using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Create GameProperties asset")]
public class GameProperties : ScriptableObject
{
    [SerializeField] private int completedGames = 0;
    public int totalGames;

    public double Progress => (double) completedGames / totalGames * 100;

    public delegate void PropertEvents();
    public PropertEvents onProgressChanged;
    public PropertEvents onAllGamesCompleted;

    public void IncrementCompletion()
    {
        completedGames = Mathf.Clamp(completedGames + 1, 0, totalGames);
        onProgressChanged?.Invoke();
        if (completedGames == totalGames) onAllGamesCompleted?.Invoke();
    }

    public void InstantiateProperties()
    {
        completedGames = 0;
    }
}
