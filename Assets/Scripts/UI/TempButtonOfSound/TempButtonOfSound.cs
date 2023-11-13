using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempButtonOfSound : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSourse;
    [SerializeField] private Button _button;

    private CanvasUI _canvasUI;

    private void OnEnable()
    {
        _canvasUI = GetComponentInParent<CanvasUI>();

        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        _audioSourse.Play();

        //_canvasUI.SoundController.SetMinSoundValue();

        AudioListener.volume = 0;
    }
}
