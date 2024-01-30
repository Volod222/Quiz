using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalResultWindow : MonoBehaviour
{
    private const string HighText = "��������\n��, ������������, ��������! ��� ������������� ������ ����������! ���� ������ ����������, ���� ������� � ��������� ��������� ���������! ��� ��� ������� � ����������� ������� ������.";
    private const string MiddleText = "������!\n����� ������! ���� ������ � ������������� � �����, ��� � ��� �������, �������� ������ ��������! ��� �������!";
    private const string LowText = "��������!\n�������! ��, ����� ����� ��������� ������������ � ������� ���� � ��������, ���� �� ��������� ������.";

    private const int Low = 35;
    private const int Middle = 60;

    [SerializeField] private Text _message;
    [SerializeField] private Text _score;
    [SerializeField] private List<Image> _icons;

    public void Show(int score, int maxQuestionCount)
    {
        HideAllIcons();

        int index = 0;
        _score.text = $"���������: {score} �� {maxQuestionCount}";

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
