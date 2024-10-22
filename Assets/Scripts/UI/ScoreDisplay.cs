using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] protected ObjectStatistics Statistics;

    [SerializeField] private string _scoreName;

    private TMP_Text _text;

    protected virtual void Awake()
    {
        _text = GetComponent<TMP_Text>();
        SetValue();
    }

    protected void SetValue(int value = 0) => _text.text = $"{_scoreName}: {value}";
}
