using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Values/BooleanValue")]
public class BooleanValue : ScriptableObject
{
    [SerializeField] private bool _value;

    public bool Value { get { return _value; } set { _value = value; } }
}
