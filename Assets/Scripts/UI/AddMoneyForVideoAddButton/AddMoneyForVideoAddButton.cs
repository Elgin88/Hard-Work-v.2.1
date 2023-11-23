using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using HardWork;

namespace HardWork
{
    public class AddMoneyForVideoAddButton : MonoBehaviour
    {
        [SerializeField] private UIRequireComponents _UIrequireComponents;
        [SerializeField] private int _addPlayerMoney;
        [SerializeField] private Button _button;
        [SerializeField] private AudioSource _moneySound;

        private WaitForSeconds _delayPressButton = new WaitForSeconds(1.5f);
        private WaitForSeconds _delayShowVideoAd = new WaitForSeconds(0.5f);

        private void Start()
        {
            _button.onClick.AddListener(OnButtonClick);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnButtonClick);
        }

        private void OnButtonClick()
        {
            _UIrequireComponents.PlayerMoney.AddMoney(_addPlayerMoney);
            _UIrequireComponents.Saver.SaveMoney();
            _moneySound.Play();

            _button.interactable = false;

            StartCoroutine(DelayForDoubleClick());
            StartCoroutine(ShowVideoAd());
        }

        private IEnumerator DelayForDoubleClick()
        {
            yield return _delayPressButton;

            _button.interactable = true;
        }

        private IEnumerator ShowVideoAd()
        {
            yield return _delayShowVideoAd;

            _UIrequireComponents.Advertising.ShowVideoAd();
        }
    }
}