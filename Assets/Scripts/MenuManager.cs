using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.InputSystem.InputAction;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private string scene;

    public void StartGame(CallbackContext context)
    {
        if (context.performed) return;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
