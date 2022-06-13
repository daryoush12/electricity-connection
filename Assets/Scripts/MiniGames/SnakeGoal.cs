using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeGoal : MonoBehaviour
{
    [SerializeField] private SnakeGameGrid _game;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Snake") return;
        collision.SendMessage("SetConnected");
        _game.Complete();
    }
}
