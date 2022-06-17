using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimations : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameProperties gameProperties;

    private void OnEnable()
    {
        gameProperties.onAllGamesCompleted += RollTheCredits;
        gameProperties.onProgressChanged += RollTheCredits;
    }

    private void OnDisable()
    {
        gameProperties.onAllGamesCompleted -= RollTheCredits;
        gameProperties.onProgressChanged -= RollTheCredits;
    }

    private void RollTheCredits()
    {
        if(gameProperties.Progress >= 100)
        {
            Debug.Log("Roll the credits");
            StartCoroutine(CreditsSequence());
        }
    }

    private IEnumerator CreditsSequence()
    {

        yield return new WaitForSeconds(2F);
        animator.SetTrigger("gameEnd");
    }
}
