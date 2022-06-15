using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeAudioSwitch : MonoBehaviour
{
    [SerializeField] private AudioClip _bgClip;
    [SerializeField] private AudioClip _origin;
    [SerializeField] private AudioClipEvent changeBackgroundEvent;
    [SerializeField] private SnakeGameGrid _grid;

    private void OnEnable()
    {
        _grid.onStop += ChangeIntoOriginal;
        _grid.onStart += ChangeIntoNew;
    }

    private void OnDisable()
    {
        _grid.onStop -= ChangeIntoOriginal;
        _grid.onStart -= ChangeIntoNew;
    }

    public void ChangeIntoOriginal()
    {
        changeBackgroundEvent.InvokeEvent(_origin);
    }

    public void ChangeIntoNew()
    {
        changeBackgroundEvent.InvokeEvent(_bgClip);
    }


}
