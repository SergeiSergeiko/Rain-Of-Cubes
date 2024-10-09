using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class SpawnedObjectsDisplay : ScoreDisplay
{
    private void Awake()
    {
        Statistics.NumberSpawnedObjectsChanged += SetValue;
    }
}
