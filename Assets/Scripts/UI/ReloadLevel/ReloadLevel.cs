using UnityEngine;
using UnityEngine.UI;

public class ReloadLevel : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private Button _button;
    [SerializeField] private UIRequireComponents _UIRequireComponents;

    private void OnEnable()
    {
        if (_panel == null|| _button == null || _UIRequireComponents == null )
        {
            Debug.Log("No Serializefield in " + gameObject.name);
        }

        _UIRequireComponents.PlayerFuelController.IsFuelChanged += OnFuelPlayerChanged;
    }

    private void OnDisable()
    {
        _UIRequireComponents.PlayerFuelController.IsFuelChanged -= OnFuelPlayerChanged;
    }

    private void OnFuelPlayerChanged(float current, float max)
    {
        if (current != 0)
        {
            return;
        }

        if (current == 0)
        {
            _panel.SetActive(true);
            _button.gameObject.SetActive(true);
        }
        else
        {
            _panel.SetActive(false);
            _button.gameObject.SetActive(false);
        }
    }
}