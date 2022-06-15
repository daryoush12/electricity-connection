using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Events/AudioClipEvent")]
public class AudioClipEvent : ScriptableObject
{
    public delegate void AudioClipEventDelegate(AudioClip clip);
    public AudioClipEventDelegate onEventInvoked;

    public void InvokeEvent(AudioClip clip)
    {
        onEventInvoked?.Invoke(clip);
    }
}
