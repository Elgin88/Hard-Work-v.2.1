using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempPauseOnButton : MonoBehaviour
{
    private PauserGame _pauserGame;
    private Button _button;

    private void Start()
    {
        _pauserGame = FindObjectOfType<PauserGame>();

        _button = GetComponent<Button>();

        _button.onClick.AddListener(OnPauseButtonClisk);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnPauseButtonClisk);
    }

    private void OnPauseButtonClisk()
    {
        _pauserGame.PauseOn();
    }
}