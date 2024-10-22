using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class ObjectsCreatedDisplay : ScoreDisplay
{
    protected override void Awake()
    {
        base.Awake();
        Statistics.NumberCreatedObjectsHasChanged += SetValue;
    }
}
