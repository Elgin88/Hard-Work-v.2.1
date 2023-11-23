using UnityEngine;
using UnityEngine.SceneManagement;

namespace HardWork
{
    public class Advertising : MonoBehaviour
    {
        [SerializeField] private PauseSetter _pauserGame;
        [SerializeField] private ScenesNames _sceneNames;

        private void Start()
        {
            if (SceneManager.GetActiveScene().name != _sceneNames.Level0Name)
            {
                ShowInterstitialAd();
            }
        }

        public void ShowVideoAd()
        {
#if UNITY_WEBGL && !UNITY_EDITOR
            Agava.YandexGames.VideoAd.Show(OnOpenCallback, OnRewardedCallback, OnCloseCallbackVideoAd, OnErrorCallback);
#endif
        }

        public void ShowInterstitialAd()
        {
#if UNITY_WEBGL && !UNITY_EDITOR
            Agava.YandexGames.InterstitialAd.Show(OnOpenCallback, OnCloseCallbackInterstitialAd, OnErrorCallback, OnErrorCallbackInterstitialAd);
#endif
        }

        private void OnErrorCallbackInterstitialAd()
        {
        }

        private void OnCloseCallbackVideoAd()
        {
            _pauserGame.PauseOffInBrauser();
        }

        private void OnCloseCallbackInterstitialAd(bool close)
        {
            _pauserGame.PauseOffInBrauser();
        }

        private void OnOpenCallback()
        {
            _pauserGame.PauseOnInBrauser();
        }

        private void OnErrorCallback(string error)
        {
        }

        private void OnOfflineCallback()
        {
        }

        private void OnRewardedCallback()
        {
        }
    }
}