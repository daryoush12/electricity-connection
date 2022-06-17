using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.InputSystem.InputAction;

public class WirePuzzle : MiniGameBase
{
    [SerializeField] private GeneralEvent onWireConnected;
    [SerializeField] private GeneralEvent onWirePuzzleCompleted;
    [SerializeField] private BooleanValue allowInput;
    [SerializeField] private int completed;
    [SerializeField] private int max = 4;

    [SerializeField] private Camera _gameCamera;
    [SerializeField] private UnityEvent onInteraction;
    [SerializeField] private GeneralEvent onWireGameActive;
    [SerializeField] private GeneralEvent onMainSceneActive;

    private Camera _mainCamera;




    private void OnEnable()
    {
        _mainCamera = Camera.main;
        onWireConnected.onEventInvoked += IncrementCompletion;
    }

    private void OnDisable()
    {
        onWireConnected.onEventInvoked -= IncrementCompletion;
    }

    private void IncrementCompletion()
    {
        completed = Mathf.Clamp(completed + 1, 0, max);

        if (completed == max)
        {
            onWirePuzzleCompleted.InvokeEvent();
            StopMiniGame();
        }
    }

    public override void ResetGame()
    {
        throw new System.NotImplementedException();
    }

    public override void StartMiniGame()
    {
        onWireGameActive.InvokeEvent();
        onInteraction?.Invoke();
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        _gameCamera.gameObject.SetActive(true);
        allowInput.Value = true;
    }

    public override void StopMiniGame()
    {
        _gameCamera.gameObject.SetActive(false);
        allowInput.Value = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        onMainSceneActive.InvokeEvent();
    }

    public void Escape(CallbackContext context) {
        if (context.performed) return;
        StopMiniGame();
    }
}
