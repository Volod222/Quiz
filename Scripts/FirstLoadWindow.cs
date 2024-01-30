using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLoadWindow : MonoBehaviour
{
    private const float Delay = 3;

    [SerializeField] private WindowChanger _windowChanger;
    [SerializeField] private int _nextWindowIndex;

    private void Start()
    {
        StartCoroutine(WaitToShowNextWindow());
    }

    private IEnumerator WaitToShowNextWindow()
    {
        yield return new WaitForSeconds(Delay);
        _windowChanger.Change(_nextWindowIndex);
    }
}
