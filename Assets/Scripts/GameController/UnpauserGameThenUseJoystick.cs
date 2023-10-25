using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnpauserGameThenUseJoystick : MonoBehaviour
{
    private FixedJoystick _fixedJoystick;
    private PauserGame _pauserGame;

    private void Start()
    {
        _fixedJoystick = FindObjectOfType<FixedJoystick>();
        _pauserGame = FindObjectOfType<PauserGame>();
    }

    private void Update()
    {
        if (_fixedJoystick != null)
        {
            if (_fixedJoystick.Horizontal != 0)
            {
                _pauserGame.PauseOff();
            }
        }
    }
}