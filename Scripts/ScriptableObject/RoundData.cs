using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RoundData", menuName = "Data/RoundData")]
public class RoundData : ScriptableObject
{
    [SerializeField] private int _numberRound;
    [SerializeField] private Sprite _icon;
    [SerializeField, TextArea(10, 20)] private string _winText;
    [SerializeField] private List<QuestionData> _questions;

    public int NumberRound => _numberRound;
    public Sprite Icon => _icon;
    public string WinText => _winText;
    public IReadOnlyList<QuestionData> Questions => _questions;
}
