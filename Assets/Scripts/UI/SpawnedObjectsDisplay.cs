using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class SpawnedObjectsDisplay : ScoreDisplay
{
    protected override void Awake()
    {
        base.Awake();
        Statistics.NumberSpawnedObjectsHasChanged += SetValue;
    }
}
