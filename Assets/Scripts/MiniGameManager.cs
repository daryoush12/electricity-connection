using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameManager : MonoBehaviour
{

    [SerializeField] private GameProperties gameProperties;

    private void Start()
    {
        gameProperties.completedGames = 0;
    }
}
