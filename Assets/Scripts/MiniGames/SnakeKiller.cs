using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeKiller : MonoBehaviour
{
    [SerializeField] private SnakeGameGrid game;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Snake")
        {
            
            collision.transform.position = collision.transform.position + 
                (collision.transform.GetComponent<Snake>().CurrentDirection);
            game.onReset?.Invoke();
        }        
    }
}
