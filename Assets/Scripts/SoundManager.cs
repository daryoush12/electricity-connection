using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource _Source;

    public void ChangeBackgroundClip(AudioClip clip)
    {
        _Source.clip = clip;
    }
}
