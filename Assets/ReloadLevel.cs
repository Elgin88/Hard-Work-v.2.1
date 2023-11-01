using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadLevel : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private Button _button;
    [SerializeField] private CanvasUI _canvasUI;

    private void OnEnable()
    {
        if (_panel==null|| _button == null || _canvasUI == null )
        {
            Debug.Log("No Serializefield in " + gameObject.name);
        }

        _canvasUI.PlayerFuelController.IsFuelChanged += OnFuelPlayerChanged;
    }

    private void OnDisable()
    {
        _canvasUI.PlayerFuelController.IsFuelChanged -= OnFuelPlayerChanged;
    }

    private void OnFuelPlayerChanged(float current, float max)
    {
        if (current != 0)
        {
            return;
        }

        if (current==0)
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
