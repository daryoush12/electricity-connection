using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeColor : MonoBehaviour
{

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private TrailRenderer trailRenderer;

    [SerializeField] Material activeMat;
    [SerializeField] Material inactiveMat;
    [SerializeField] Material connectedMat;

    private void OnEnable()
    {
        SetActive();
    }

    public void SetActive()
    {
        trailRenderer.material = activeMat;
        spriteRenderer.material = activeMat;
    }

    public void SetInActive()
    {
        trailRenderer.material = inactiveMat;
        spriteRenderer.material = inactiveMat;
    }

    public void SetConnected()
    {
        trailRenderer.material = connectedMat;
        spriteRenderer.material = connectedMat;
    }
}
