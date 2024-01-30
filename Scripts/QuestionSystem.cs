using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuestionSystem : MonoBehaviour
{
    private const int RoundWindowIndex = 3;
    private const int FinalWindowIndex = 7;
    private const int ResultWindowIndex = 6;

    [SerializeField] private FinalResultWindow _finalResultWindow;
    [SerializeField] private ResultWindowDisplay _resultWindow;
    [SerializeField] private RoundDisplayDisplay _roundDisplay;
    [SerializeField] private QuestionDisplay _questionDisplay;
    [SerializeField] private WindowChanger _windowChanger;
    [SerializeField] private List<RoundData> _datas;

    private List<QuestionData> _questionDatas;
    private RoundData _currentRoundData;
    private int _indexRound = 0;
    private int _questionCount = 0;
    private int _correctAnswerCount = 0;
    private int _score = 0;

    public void StartPlay()
    {
        Reset();
        NextRound();
    }

    public void Reset()
    {
        _indexRound = 0;
        _questionCount = 0;
        _correctAnswerCount = 0;
        _score = 0;
        _currentRoundData = null;
    }

    public void GenerateRandomQuestion()
    {
        if (TryGetRandomQuestion(out QuestionData data))
        {
            _questionCount++;
            _questionDisplay.Init(data, _questionCount);
            _questionDatas.Remove(data);
        }
        else
        {
            _score += _correctAnswerCount;
            _windowChanger.Change(ResultWindowIndex);
            _resultWindow.Show(_currentRoundData, _correctAnswerCount, _score);
        }
    }

    public void NextRound()
    {
        YandexAd.Instance.ShowFullscreenAd();

        _correctAnswerCount = 0;

        if (TryGetNextRoundData(out RoundData data))
        {
            _currentRoundData = data;

            _questionDatas = _currentRoundData.Questions.ToList();
            _roundDisplay.Init(_currentRoundData);
            _windowChanger.Change(RoundWindowIndex);
            _questionCount = 0;
        }
        else
        {
            int maxQuestionCount = _datas.SelectMany(round => round.Questions).Count();

            _windowChanger.Change(FinalWindowIndex);
            _finalResultWindow.Show(_score, maxQuestionCount);
        }
    }

    public void AddScore()
    {
        _correctAnswerCount++;
    }

    private bool TryGetRandomQuestion(out QuestionData data)
    {
        data = null;

        if (_questionDatas.Count == 0)
            return false;

        data = _questionDatas.Shuffle().FirstOrDefault();
        return true;
    }

    private bool TryGetNextRoundData(out RoundData data)
    {
        data = null;

        if (_currentRoundData == null)
        {
            data = _datas[_indexRound];
            return true;
        }

        _indexRound++;

        if (_indexRound > _datas.Count - 1)
            return false;

        data = _datas[_indexRound];
        return true;
    }
}
