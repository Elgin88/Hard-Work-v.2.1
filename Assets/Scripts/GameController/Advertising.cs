using HardWork.Player;
using HardWork.SaverAndLoader;
using HardWork.SceneLoader;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace HardWork.GameController
{
    public class Advertising : MonoBehaviour
    {
        [SerializeField] private PauseSetter _pauserGame;
        [SerializeField] private PlayerMoney _playerMoney;
        [SerializeField] private Saver _saver;
        [SerializeField] private Button _buttonForVideoAdd;

        private int _moneyCountForVideoAd = 750;

        private void Start()
        {
            if (SceneManager.GetActiveScene().name != ScenesNames.Level0Name)
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
            _playerMoney.AddMoney(_moneyCountForVideoAd);
            _saver.SaveMoney();
            _buttonForVideoAdd.interactable = true;
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

        private void OnRewardedCallback()
        {
        }
    }
}