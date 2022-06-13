using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PersonalComputer : MonoBehaviour
{
    [SerializeField] private GameProperties gameProperties;
    [SerializeField] private SnakeGameGrid SnakeGameGrid;
    [SerializeField] private TextMeshProUGUI screen;
    [SerializeField] private Collider col;

    

    private void OnEnable()
    {
        gameProperties.onProgressChanged += UpdateProgress;
        SnakeGameGrid.onSolved += DisableCollision;
    }

    private void OnDisable()
    {
        gameProperties.onProgressChanged -= UpdateProgress;
        SnakeGameGrid.onSolved -= DisableCollision;
    }

    private void Start()
    {
        UpdateProgress();
    }

    public void SetText(string value)
    {
        screen.text = value;
    }

    private void UpdateProgress()
    {
        SetText($"{gameProperties.Progress} %");
    }

    private void DisableCollision()
    {
        col.enabled = false;
    }
}
