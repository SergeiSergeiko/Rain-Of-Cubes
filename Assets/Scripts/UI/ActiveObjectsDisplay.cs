using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class ActiveObjectsDisplay : ScoreDisplay
{
    protected override void Awake()
    {
        base.Awake();
        Statistics.NumberActiveObjectsHasChanged += SetValue;
    }
}
