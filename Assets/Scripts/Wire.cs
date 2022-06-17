using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour
{
    [SerializeField] private GameObject _wire;
    [SerializeField] private int length;
    [SerializeField] private float ropeScale;
    [SerializeField] private GameObject[] _wires;
    [SerializeField] private HingeJoint2D _start;
    [SerializeField] private HingeJoint2D _end;
    [SerializeField] private GameObject _head;

    private void Start()
    {
        InitWire();
    }

    private void InitWire()
    {
        _wires = new GameObject[length];
        for(int i = 0; i < length; i++)
        {
            GameObject ob = Instantiate(_wire);
            ob.transform.SetParent(transform);
            
            if (i > 0)
            {
                _wires[i - 1].GetComponent<HingeJoint2D>().connectedBody 
                    = ob.GetComponent<Rigidbody2D>();
                ob.transform.position +=
                new Vector3(ob.transform.lossyScale.x * i / 2, 0F, 0F);
            }else
            {
                ob.transform.position = _start.transform.position + ob.transform.localScale;
                _start.connectedBody = ob.GetComponent<Rigidbody2D>();
            }


            _wires[i] = ob;

        }
    }
}
