using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class InterstitialAdUnity : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    public static InterstitialAdUnity S;

    [SerializeField] private string _androidIDAd = "Interstitial_Android";
    [SerializeField] private string _iOSIDAd = "Interstitial_iOS";
    private string _adId;

    private void Awake()
    {
        S = this;

        _adId = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? _iOSIDAd
            : _androidIDAd;
    }

    public void LoadAd()
    {
        Debug.Log("Loading Ad" + _adId);
        Advertisement.Load(_adId, this);
    }

    public void ShowAd()
    {
        Debug.Log("Showing Ad" + _adId);
        Advertisement.Show(_adId, this);
    }

    void IUnityAdsLoadListener.OnUnityAdsAdLoaded(string placementId)
    {

    }

    void IUnityAdsLoadListener.OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Eror loading Ad Unit: {_adId} - {error} - {message}");
    }

    void IUnityAdsShowListener.OnUnityAdsShowClick(string placementId)
    {

    }

    void IUnityAdsShowListener.OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        LoadAd();
    }

    void IUnityAdsShowListener.OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Eror loading Ad Unit: {_adId} - {error} - {message}");
    }

    void IUnityAdsShowListener.OnUnityAdsShowStart(string placementId)
    {

    }
}
