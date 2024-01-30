using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultWindowDisplay : MonoBehaviour
{
    [SerializeField] private Text _message;
    [SerializeField] private Text _score;

    public void Show(RoundData data, int correctAnswerCount, int score)
    {
        _message.text = data.WinText;

        string message = $"{data.NumberRound} �����: {correctAnswerCount} �� {data.Questions.Count}\n";
        string scoreText = $"����� ����: {score}";

        _score.text = data.NumberRound == 0 ? scoreText : message + scoreText;
    }
}
