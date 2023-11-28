using UnityEngine;
using UnityEngine.UI;

namespace HardWork
{
    public class ReloadLevel : MonoBehaviour
    {
        [SerializeField] private GameObject _panel;
        [SerializeField] private Button _button;
        [SerializeField] private RequireComponentsForUI _requireComponentsForUI;

        private void OnEnable()
        {
            _requireComponentsForUI.PlayerFuelController.IsFuelChanged += OnFuelPlayerChanged;
        }

        private void OnDisable()
        {
            _requireComponentsForUI.PlayerFuelController.IsFuelChanged -= OnFuelPlayerChanged;
        }

        private void OnFuelPlayerChanged(float current, float max)
        {
            if (current != 0)
            {
                _panel.SetActive(false);
                _button.gameObject.SetActive(false);
                return;
            }

            if (current == 0)
            {
                _panel.SetActive(true);
                _button.gameObject.SetActive(true);
            }
        }
    }
}