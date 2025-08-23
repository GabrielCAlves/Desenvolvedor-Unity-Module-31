using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FlashColor : MonoBehaviour
{
    public MeshRenderer meshRenderer;

    [Header("Setup")]
    public Color color = Color.red;
    public float duration = .2f;

    private Color _defaultColor;

    private Tween _currentTween;

    private void Start()
    {
        _defaultColor = meshRenderer.material.GetColor("_EmissionColor");
    }

    private void Update()
    {
        if (meshRenderer.material.GetColor("_EmissionColor") != _defaultColor)
        {
            meshRenderer.material.SetColor("_EmissionColor", _defaultColor);
        }
    }

    [NaughtyAttributes.Button]
    public void Flash()
    {
        if (!_currentTween.IsActive())
        {
            meshRenderer.material.DOColor(color, "_EmissionColor", duration).SetLoops(2, LoopType.Yoyo);
            new WaitForEndOfFrame();
        }
    }
}
