using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class Cube : Unit
{
    private MeshRenderer _renderer;
    private Tween _tween;
    private Color _defaultColor;
    private Color _invisibilityColor;

    protected override void OnEnable()
    {
        base.OnEnable();
        _tween = _renderer.material.DOColor(_invisibilityColor, LifeTime);
    }

    private void OnDisable()
    {
        _tween.Kill();
        _renderer.material.color = _defaultColor;
    }

    private void Awake()
    {
        _renderer = GetComponent<MeshRenderer>();
        _defaultColor = _renderer.material.color;
        _invisibilityColor = GetYourColorAlpha0();
    }

    private Color GetYourColorAlpha0()
    {
        float alpha = 0;

        Color color = _renderer.material.color;
        color.a = alpha;

        return color;
    }
}