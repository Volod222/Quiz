using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestionData", menuName = "Data/QuestionData")]
public class QuestionData : ScriptableObject
{
    [SerializeField] private Sprite _icon;
    [SerializeField, TextArea(10, 20)] private string _question;
    [SerializeField] private List<string> _answers;

    public Sprite Icon => _icon;
    public string Question => _question;
    public IReadOnlyList<string> Answers => _answers;
}
