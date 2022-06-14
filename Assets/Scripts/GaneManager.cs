using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaneManager : MonoBehaviour
{
    [SerializeField] private GameProperties gameProperties;

    private void Start()
    {
        gameProperties.InstantiateProperties();
    }
}
