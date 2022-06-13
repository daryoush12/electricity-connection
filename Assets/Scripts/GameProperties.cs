using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Create GameProperties asset")]
public class GameProperties : ScriptableObject
{
    public int completedGames;
    public int totalGames;

    public double Progress => (double) completedGames / totalGames * 100;

    public delegate void PropertEvents();
    public PropertEvents onProgressChanged;
}
