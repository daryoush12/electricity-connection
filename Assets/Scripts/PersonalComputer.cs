using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PersonalComputer : MonoBehaviour
{
    [SerializeField] private GameProperties gameProperties;
    [SerializeField] private TextMeshProUGUI screen;

    private void OnEnable()
    {
        gameProperties.onProgressChanged += UpdateProgress; 
    }

    private void OnDisable()
    {
        gameProperties.onProgressChanged -= UpdateProgress;
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
        SetText($"Current progress: {gameProperties.Progress} %");
    }

}
