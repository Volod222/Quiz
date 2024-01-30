using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowChanger : MonoBehaviour
{
    [SerializeField] private List<GameObject> _windows;

    public void Change(int index)
    {
        if (index < 0)
            index = 0;

        if (index > _windows.Count)
            index = _windows.Count - 1;

        HideAllWindows();
        _windows[index].SetActive(true);
    }

    private void HideAllWindows()
    {
        foreach (var window in _windows)
            window.SetActive(false);
    }
}
