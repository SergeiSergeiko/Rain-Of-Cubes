using DG.Tweening;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private MeshRenderer _meshRenderer;

    private Tween _tween;
    private Color _defaultColor;

    private void Start()
    {
        _defaultColor = _meshRenderer.material.color;
    }

    private void OnDisable()
    {
        _tween.Kill();
    }

    public void SetColor(Color color)
    {
        _meshRenderer.material.color = color;
    }

    public void ChangeColorRandomly()
    {
        Color randomColor = GetColorRandomly();

        _meshRenderer.material.color = randomColor;
    }

    public void SetTransparentColor(float inTime)
    {
        Color invisibilityColor = GetYourColorAlpha0();

        _tween = _meshRenderer.material.DOColor(invisibilityColor, inTime);
    }

    public void ResetColor()
    {
        SetColor(_defaultColor);
    }

    private Color GetYourColorAlpha0()
    {
        float alpha = 0;

        Color color = _meshRenderer.material.color;
        color.a = alpha;

        return color;
    }

    private Color GetColorRandomly()
    {
        float red = Random.Range(0f, 1f);
        float green = Random.Range(0f, 1f);
        float blue = Random.Range(0f, 1f);

        return new Color(red, green, blue);
    }
}