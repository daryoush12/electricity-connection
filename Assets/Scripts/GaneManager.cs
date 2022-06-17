using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaneManager : MonoBehaviour
{
    [SerializeField] private GameProperties gameProperties;
    [SerializeField] private AudioClipEvent backgroundChangeEvent;

    private void Start()
    {
        gameProperties.InstantiateProperties();
    }

  
}
