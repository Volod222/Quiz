using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class YandexAd : MonoBehaviour
{
    private static YandexAd _instance;

    public static YandexAd Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<YandexAd>();

            return _instance;
        }
    }

    public void ShowFullscreenAd()
    {
        AudioListener.pause = true;
        ShowAd();
    }

    [DllImport("__Internal")]
    private static extern void ShowAd();
}
