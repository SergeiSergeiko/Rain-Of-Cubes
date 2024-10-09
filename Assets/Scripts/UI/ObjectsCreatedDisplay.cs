using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class ObjectsCreatedDisplay : ScoreDisplay
{
    private void Awake()
    {
        Statistics.NumberObjectsCreatedChanged += SetValue;
    }
}
