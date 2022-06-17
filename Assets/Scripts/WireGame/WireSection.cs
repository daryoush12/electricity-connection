using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireSection : MonoBehaviour
{
    [SerializeField] private Color _wireColor;
    [SerializeField] private Material lineMat;
    [SerializeField] private Material socketMat;

    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private SpriteRenderer[] _renderers;

    public void InitWireSection()
    {
        for (int i = 0; i < _renderers.Length; i++)
        {
            _renderers[i].color = _wireColor;
        }

        lineRenderer.material = lineMat;
    }

    public Color GetWireColor() { return _wireColor; }

    public Material GetLineMaterial() { return lineMat; }

    public Material GetSocketMaterial() { return socketMat; }
}
