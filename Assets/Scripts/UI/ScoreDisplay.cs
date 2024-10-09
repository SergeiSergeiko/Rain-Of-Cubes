using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] protected ObjectStatistics Statistics;

    [SerializeField] private string _scoreName;

    private TMP_Text _text;

    private void OnEnable()
    {
        _text = GetComponent<TMP_Text>();
    }

    protected void SetValue(int value) => _text.text = $"{_scoreName}: {value}";
}
