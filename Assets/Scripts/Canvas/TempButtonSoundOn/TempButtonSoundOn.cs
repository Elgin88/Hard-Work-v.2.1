using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

public class TempButtonSoundOn : MonoBehaviour
{
    [SerializeField] private Button _buttonOn;
    [SerializeField] private CanvasUI _canvasUI;

    private void OnEnable()
    {
        _buttonOn.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _buttonOn.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        _canvasUI.SoundController.SetMaxSoundValue();
    }
}