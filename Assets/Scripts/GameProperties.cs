using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Create GameProperties asset")]
public class GameProperties : ScriptableObject
{
    public int completedGames;
    public int totalGames;

    public delegate void PropertEvents();
    public PropertEvents onProgressChanged;
}
