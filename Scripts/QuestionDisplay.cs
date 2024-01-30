using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class QuestionDisplay : MonoBehaviour
{
    [SerializeField] private QuestionSystem _questionSystem;
    [SerializeField] private Image _icon;
    [SerializeField] private Text _questionText;
    [SerializeField] private Text _questionCountText;
    [SerializeField] private Button _nextQuestion;
    [SerializeField] private List<Button> _answers;

    private string _correctAnswer = string.Empty;

    public void Init(QuestionData data, int questionCount)
    {
        Reset();

        _icon.sprite = data.Icon;
        _questionText.text = data.Question;
        _questionCountText.text = $"бнопня {questionCount}";

        var randomAnswers = data.Answers.Shuffle().ToList();
        _correctAnswer = data.Answers[0];

        for (int i = 0; i < randomAnswers.Count && i < _answers.Count; i++)
        {
            if (_answers[i].transform.GetChild(0).TryGetComponent(out Text text))
            {
                text.text = randomAnswers[i];
                string answer = randomAnswers[i];
                Button button = _answers[i];
                _answers[i].onClick.AddListener(() => Next(button, answer));
            }
        }
    }

    private void Reset()
    {
        _correctAnswer = string.Empty;

        foreach (var answer in _answers)
        {
            answer.interactable = true;
            answer.targetGraphic.color = Color.white;
            answer.onClick.RemoveAllListeners();
        }

        _nextQuestion.gameObject.SetActive(false);
    }

    private void Next(Button currentButton, string answer)
    {
        bool isCorrectAnswer = _correctAnswer == answer;

        if (isCorrectAnswer)
            _questionSystem.AddScore();

        Color color = isCorrectAnswer ? Color.green : Color.red;
        currentButton.targetGraphic.color = color;
        _nextQuestion.gameObject.SetActive(true);

        foreach (var button in _answers)
            button.interactable = false;
    }
}
