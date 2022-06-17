using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class WireDragger : MonoBehaviour
{
    [SerializeField] private Vector2 _mousePos;
    [SerializeField] private Vector2 _mouseWorldPos;
    [SerializeField] private Camera _camera;
    [SerializeField] private BooleanValue allowInput;

    [SerializeField] private Transform _toDrag;
    [SerializeField] private bool shouldDrag;

    private void Start()
    {
        shouldDrag = false;
    }

    private void Update()
    {
        if (_toDrag != null && shouldDrag)
        {
            _toDrag.position = _mouseWorldPos;
        }
    }

    public void GetMousePosition(CallbackContext context)
    {
        if (!allowInput.Value) return;
        _mousePos = context.ReadValue<Vector2>();
        _mouseWorldPos = _camera.ScreenToWorldPoint(_mousePos);
    }

    public void DragWire(CallbackContext context)
    {
        if (!allowInput.Value) return;
        if (context.started)
        {
            Debug.Log("Dragging");
            var rs = Physics2D.OverlapCircle(_mouseWorldPos, 0.5F);
            rs.TryGetComponent<WireHead>(out var head);

            if (head != null)
            {
                _toDrag = rs.transform;
                shouldDrag = true;
            } 
        }else if (context.canceled && _toDrag != null)
        {
            Debug.Log("Not Dragging");
            shouldDrag = false;
            _toDrag.SendMessage("ConnectWire");
            _toDrag = null;
        }
    }
}
