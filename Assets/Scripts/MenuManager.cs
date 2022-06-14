using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.InputSystem.InputAction;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private string scene;
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip startClip;

    public void StartGame(CallbackContext context)
    {
        if (context.performed || context.started) return;
        StartCoroutine(StartCycle());   
    }

    private IEnumerator StartCycle()
    {
        _source.PlayOneShot(startClip);
        yield return new WaitForSeconds(startClip.length);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
