using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalResultWindow : MonoBehaviour
{
    private const string HighText = "КИНОГУРУ\nНу, здравствуйте, КИНОГУРУ! Это действительно крутое достижение! Ваши знания впечатляют, ваша страсть к экранному искусству восхищает! Вот вам награда – виртуальная золотая медаль.";
    private const string MiddleText = "ЗНАТОК!\nОчень хорошо! Ваша любовь к кинематографу и всему, что с ним связано, вызывает только уважение! Так держать!";
    private const string LowText = "ЛЮБИТЕЛЬ!\nНеплохо! Но, чтобы стать настоящим специалистом в области кино и сериалов, надо бы подтянуть знания.";

    private const int Low = 35;
    private const int Middle = 60;

    [SerializeField] private Text _message;
    [SerializeField] private Text _score;
    [SerializeField] private List<Image> _icons;

    public void Show(int score, int maxQuestionCount)
    {
        HideAllIcons();

        int index = 0;
        _score.text = $"РЕЗУЛЬТАТ: {score} из {maxQuestionCount}";

        if (Middle <= score)
        {
            index = 0;
            _message.text = HighText;
        }
        else if (Low <= score)
        {
            index = 1;
            _message.text = MiddleText;
        }
        else
        {
            index = 2;
            _message.text = LowText;
        }

        _icons[index].enabled = true;
    }

    private void HideAllIcons()
    {
        foreach (var icon in _icons)
            icon.enabled = false;
    }
}
