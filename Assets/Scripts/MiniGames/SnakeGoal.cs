using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SnakeGoal : MonoBehaviour
{
    [SerializeField] private SnakeGameGrid _game;
    [SerializeField] private UnityEvent onSnakeHitGoal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Snake")) return;
        collision.SendMessage("SetConnected");
        StartCoroutine(CompleteCycle());  
    }

    private IEnumerator CompleteCycle()
    {
        onSnakeHitGoal?.Invoke();
        yield return new WaitForSeconds(0.5F);
        _game.Complete();
    }
}
