using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class ActiveObjectsDisplay : ScoreDisplay
{
    private void Awake()
    {
        Statistics.NumberActiveObjectsHasChanged += SetValue;
    }
}
