using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource _Source;
    [SerializeField] private AudioClipEvent audioClipEvent;

    private void OnEnable()
    {
        audioClipEvent.onEventInvoked += ChangeBackgroundClip;
    }

    private void OnDisable()
    {
        audioClipEvent.onEventInvoked -= ChangeBackgroundClip;
    }

    public void ChangeBackgroundClip(AudioClip clip)
    {
        _Source.clip = clip;
        _Source.Play();
    }
}
