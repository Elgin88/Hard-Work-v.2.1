using System.Collections;
using TMPro;
using UnityEngine;

public class TurnOffSoundWhenMinimizingGame : MonoBehaviour
{
    private SoundController _soundController;
    private bool _isSoundOffThenMinimozing;

    private void Start()
    {
        _soundController = FindObjectOfType<SoundController>();

        _isSoundOffThenMinimozing = false;
    }

    private void FixedUpdate()
    {
        if (CheckInBackgrounInBrauser() == true & _isSoundOffThenMinimozing == false)
        {
            _soundController.SetMinSoundValue();
            _isSoundOffThenMinimozing = true;
        }
        else if (CheckInBackgrounInBrauser() == false & _isSoundOffThenMinimozing == true)
        {
            _soundController.SetMaxSoundValue();
            _isSoundOffThenMinimozing = false;
        }
    }

    private bool CheckInBackgrounInBrauser()
    {
#if UNITY_EDITOR
        return false;
#endif

#if UNITY_WEBGL
        return Agava.WebUtility.WebApplication.InBackground;
#endif
    }
}