using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    private bool _isMute = false;

    private void OnApplicationFocus(bool focus)
    {
        AudioListener.pause = focus == false;
    }

    private void OnApplicationPause(bool isPause)
    {
        AudioListener.pause = isPause;
    }

    public void Mute()
    {
        _isMute = !_isMute;
        AudioListener.pause = _isMute;
    }

    public void EnableSound()
    {
        AudioListener.pause = false;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
