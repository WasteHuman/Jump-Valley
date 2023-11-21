using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class Ads : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField] private string _androidId;
    [SerializeField] private string _iOSId;
    [SerializeField] private bool _testMode;

    public static Ads A;

    private string _gameId;

    private void Awake()
    {
        A = this;
        InizializeAds();
    }

    public void InizializeAds()
    {
        _gameId = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? _iOSId
            : _androidId;

        Advertisement.Initialize(_gameId, _testMode, this);
    }

    void IUnityAdsInitializationListener.OnInitializationComplete()
    {
        Debug.Log("Inizialization complete");
    }

    void IUnityAdsInitializationListener.OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log("Inizialization failed");
    }
}
