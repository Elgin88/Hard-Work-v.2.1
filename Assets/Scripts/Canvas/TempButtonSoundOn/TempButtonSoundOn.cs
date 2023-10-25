using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

public class TempButtonSoundOn : MonoBehaviour
{
    [SerializeField] private Button _buttonOn;

    private SoundController _soundController;

    private void OnEnable()
    {
        _soundController = FindObjectOfType<SoundController>();

        _buttonOn.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _buttonOn.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        _soundController.SetMaxSoundValue();
    }
}