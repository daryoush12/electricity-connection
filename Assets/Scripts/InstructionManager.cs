using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionManager : MonoBehaviour
{
    [SerializeField] private GeneralEvent onSnakeGameActive;
    [SerializeField] private GeneralEvent onWireGameActive;
    [SerializeField] private GeneralEvent onMainSceneActive;

    [SerializeField] private RectTransform _mainView;
    [SerializeField] private RectTransform _wireView;
    [SerializeField] private RectTransform _snakeView;

    private void OnEnable()
    {
        onSnakeGameActive.onEventInvoked += SnakeInstructionView;
        onWireGameActive.onEventInvoked += WireInstructionView;
        onMainSceneActive.onEventInvoked += MainInstructionView;
    }

    private void OnDisable()
    {
        onSnakeGameActive.onEventInvoked -= SnakeInstructionView;
        onWireGameActive.onEventInvoked -= WireInstructionView;
        onMainSceneActive.onEventInvoked -= MainInstructionView;
    }


    public void WireInstructionView()
    {
        _snakeView.gameObject.SetActive(false);
        _wireView.gameObject.SetActive(true);
        _mainView.gameObject.SetActive(false);
    }

    public void SnakeInstructionView()
    {
        _snakeView.gameObject.SetActive(true);
        _wireView.gameObject.SetActive(false);
        _mainView.gameObject.SetActive(false);
    }

    public void MainInstructionView()
    {
        _snakeView.gameObject.SetActive(false);
        _wireView.gameObject.SetActive(false);
        _mainView.gameObject.SetActive(true);
    }
}
