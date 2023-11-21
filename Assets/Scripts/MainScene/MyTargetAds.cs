using UnityEngine;
using System;
using Mycom.Target.Unity.Internal;
using Mycom.Target.Unity.Common;
using Mycom.Target.Unity.Ads;

public class MyTargetAds : MonoBehaviour
{
    public static MyTargetAds S;

    private  InterstitialAd _interstitialAd;

    void Awake()
    {
        S = this;
    }

    public void InitAd()
    {
        _interstitialAd = CreateIntAd();

        //���������� �������
        _interstitialAd.AdLoadCompleted += OnLoadCompleted;
        _interstitialAd.AdDismissed += OnAdDismissed;
        _interstitialAd.AdDisplayed += OnAdDisplayed;
        _interstitialAd.AdVideoCompleted += OnAdVideoCompleted;
        _interstitialAd.AdClicked += OnAdClicked;
        _interstitialAd.AdLoadFailed += OnAdLoadFailed;

        //�������� ������
        _interstitialAd.Load();
    }
    private InterstitialAd CreateIntAd()
    {
        uint slotId = 1298007;

        return new InterstitialAd(slotId);
    }

    public void OnLoadCompleted(object sender, EventArgs e)
    {
        _interstitialAd.Show();
    }

    private void OnAdDismissed(object sender, EventArgs e)
    {

    }

    private void OnAdDisplayed(object sender, EventArgs e)
    {

    }

    private void OnAdVideoCompleted(object sender, EventArgs e)
    {

    }

    private void OnAdClicked(object sender, EventArgs e)
    {

    }

    private void OnAdLoadFailed(object sender, ErrorEventArgs e)
    {
        Debug.Log("OnAdLoadFailed: " + e.Message);
    }
}
