using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempPauseButton : MonoBehaviour
{
    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();

        _button.onClick.AddListener(OnPauseButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnPauseButtonClick);
    }

    private void OnPauseButtonClick()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            AudioListener.pause = true;
        }
        else
        {
            Time.timeScale = 1;
            AudioListener.pause = false;
        }
    }
}
