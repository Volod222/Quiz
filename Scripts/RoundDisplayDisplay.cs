using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundDisplayDisplay : MonoBehaviour
{
    [SerializeField] private Image _icon;

    public void Init(RoundData data)
    {
        _icon.sprite = data.Icon;
    }
}
