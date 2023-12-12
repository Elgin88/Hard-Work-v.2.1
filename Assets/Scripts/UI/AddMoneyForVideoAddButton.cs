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

        private WaitForSeconds _delayShowVideoAd = new WaitForSeconds(0.5f);
        private WaitForSeconds _timeToInteractableButton = new WaitForSeconds(3);

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

            StartCoroutine(ShowVideoAd());
            StartCoroutine(InteractableButton());
        }

        private IEnumerator ShowVideoAd()
        {
            yield return _delayShowVideoAd;

            _requireComponentsForUI.Advertising.ShowVideoAd();
        }

        private IEnumerator InteractableButton()
        {
            yield return _timeToInteractableButton;

            _button.interactable = true;
        }
    }
}