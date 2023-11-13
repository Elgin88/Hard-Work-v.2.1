using UnityEngine;
using UnityEngine.UI;

public class TempButtonSoundOff : MonoBehaviour
{
    [SerializeField] private Button _buttonSoundOff;
    [SerializeField] private CanvasUI _canvasUI;

    private void Start()
    {
        if (_buttonSoundOff == null || _canvasUI == null)
        {
            Debug.Log("No serializefiel in " + gameObject.name);
        }

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