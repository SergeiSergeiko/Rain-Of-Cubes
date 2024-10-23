using UnityEngine;

public class Cube : Unit
{
    [SerializeField] private ColorChanger _colorChanger;

    private bool _isColorChanged = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Platform _))
            CollidePlatformTrigger();
    }

    public void CollidePlatformTrigger()
    {
        if (_isColorChanged)
            return;

        ChangeColorRandomly();
        StartLifeTimer();
    }

    protected override void Die()
    {
        ResetColor();
        base.Die();
    }

    private void ChangeColorRandomly()
    {
        _colorChanger.ChangeColorRandomly();
        _isColorChanged = true;
    }

    private void ResetColor()
    {
        _colorChanger.ResetColor();
        _isColorChanged = false;
    }
}