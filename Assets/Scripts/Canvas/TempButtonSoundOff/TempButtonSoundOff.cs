using UnityEngine;
using UnityEngine.UI;

public class TempButtonSoundOff : MonoBehaviour
{
    [SerializeField] private Button _buttonSoundOff;
    [SerializeField] private CanvasUI _canvasUI;

    private void Start()
    {
        _buttonSoundOff.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _buttonSoundOff.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        _canvasUI.SoundController.SetMinSoundValue();
    }
}