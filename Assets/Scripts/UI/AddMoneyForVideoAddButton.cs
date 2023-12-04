using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace HardWork.UI
{
    public class AddMoneyForVideoAddButton : MonoBehaviour
    {
        [SerializeField] private RequireComponentsForUI _requireComponentsForUI;
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

            _requireComponentsForUI.Advertising.ShowVideoAd();
        }
    }
}