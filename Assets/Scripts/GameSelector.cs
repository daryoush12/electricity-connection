using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class GameSelector : MonoBehaviour
{
    private Vector2 m_Position = Vector2.zero;
    private Camera m_Camera;
    private RaycastHit info;
    [SerializeField] private Transform current;

    [SerializeField] private float m_Distance = 10F;
    [SerializeField] private LayerMask gameMask;
    

    private void OnEnable()
    {
        m_Camera = GetComponent<Camera>();
        current = null;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnDrawGizmos()
    {
        if(m_Position != null && m_Camera != null)  Gizmos.DrawRay(m_Camera.ScreenPointToRay(m_Position));
    }

    private void FixedUpdate()
    {
        HighlightMiniGame();
    }

    public void ReadMousePosition(CallbackContext context)
    {
        m_Position = context.ReadValue<Vector2>();
    }

    public void HighlightMiniGame()
    {
        Physics.Raycast(m_Camera.ScreenPointToRay(m_Position), out info, 10F, gameMask);
        if (info.collider == null && current == null) return;

        if (info.collider == null && current != null) {
            current.SendMessage("CancelHighlight");
            current = null;
            return; 
        }

        else if (current != null && current != info.collider.transform)
        {
            current.SendMessage("CancelHighlight");
            current = info.collider.transform;
            current.SendMessage("HighlightObject");
        }
               
        else
        {  
            current = info.collider.transform;
            current.SendMessage("HighlightObject");
        }
    }

    public void SelectMiniGame(CallbackContext context)
    {
        Debug.Log($"Select minigame {current.name}");
        
        current.GetComponent<PuzzlePointer>().OpenPuzzle();
    }
}
