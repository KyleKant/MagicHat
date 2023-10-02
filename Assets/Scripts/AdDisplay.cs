using UnityEngine;
using UnityEngine.Advertisements;

public class AdDisplay : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
{
    public const string ANDROID_ID = "5432809";
    public const string iOS_ID = "5432808";
    public string idAndroid = ANDROID_ID;
    public string idIOS = iOS_ID;
    public string adsUnitIdAndroid = "Interstitial_Android";
    public string adsUnitIdiOS = "Interstitial_iOS";
    public string myAdUnitID;
    public bool adStarted;
    public bool testMode = true;

    public void OnInitializationComplete()
    {
        Debug.Log("Complete initialize the advertisement.");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Ads Initialization Error: {error}: {message}");
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log($"{placementId} ads loaded.");
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"{placementId} Load Ads failed: {error}: {message}");
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        Debug.Log($"OnUnityAdsShowClick: {placementId}");
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        Debug.Log($"{placementId} OnUnityAdsShowComplete: {showCompletionState}");
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.Log($"{placementId} OnUnityAdsShowFailure: {error}: {message}");
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        Debug.Log($"OnUnityAdsShowStart: {placementId}");
    }

    private void Start()
    {
#if UNITY_ANDROID
        Advertisement.Initialize(idAndroid, testMode, this);
        myAdUnitID = adsUnitIdAndroid;
#else
        Advertisement.Initialize(idIOS, testMode);
        myAdUnitID = adsUnitIdiOS;
#endif
    }
    private void Update()
    {
        if (Advertisement.isInitialized && !adStarted)
        {
            Advertisement.Load(myAdUnitID, this);
            Advertisement.Show(myAdUnitID, this);
            adStarted = true;
        }
    }
}
