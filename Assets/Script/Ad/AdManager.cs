using System.Collections;
using System.Collections.Generic;
using Framework;
using UnityEngine;
using GoogleMobileAds.Api;

namespace SuperSport
{
    public class AdManager : MonoSingleton<AdManager>
    {
        BannerView _bottomBannerView;
        InterstitialAd _interstitial;
        
        protected override void OnAwake()
        {
#if UNITY_ANDROID
            string appId = "ca-app-pub-3940256099942544~3347511713";
#elif UNITY_IOS
            string appId = "ca-app-pub-1345255041192804~2662425465";
#else
            string appId = "unexpected_platform";
#endif
            MobileAds.Initialize(appId);

            RequestBottomBanner();
        }
        
        void RequestBottomBanner()
        {
#if UNITY_ANDROID
            string adUnitId = "ca-app-pub-3940256099942544/6300978111";
#elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-1345255041192804/7531608764";
#else
            string adUnitId = "unexpected_platform";
#endif
            _bottomBannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);
            
            AdRequest request = new AdRequest.Builder().Build();
            
            _bottomBannerView.LoadAd(request);
        }

        void RequestInterstitial()
        {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-3940256099942544/1033173712";
#elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-1345255041192804/9746515049";
#else
        string adUnitId = "unexpected_platform";
#endif
            _interstitial = new InterstitialAd(adUnitId);
            
            AdRequest request = new AdRequest.Builder().Build();
            
            _interstitial.LoadAd(request);
        }

        public void Show()
        {
            RequestInterstitial();
            StartCoroutine(DoShow());
        }

        IEnumerator DoShow()
        {
            while(!_interstitial.IsLoaded())
            {
                yield return null;
            }
            
            _interstitial.Show();
        }
    }    
}
