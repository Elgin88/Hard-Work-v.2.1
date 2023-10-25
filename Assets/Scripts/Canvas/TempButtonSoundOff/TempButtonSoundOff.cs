using UnityEngine;
using UnityEngine.UI;

public class TempButtonSoundOff : MonoBehaviour
{
    [SerializeField] private Button _buttonSoundOff;

    private SoundController _soundController;

    private void Start()
    {
        _soundController = FindObjectOfType<SoundController>();
        _buttonSoundOff.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _buttonSoundOff.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        _soundController.SetMinSoundValue();
    }
}