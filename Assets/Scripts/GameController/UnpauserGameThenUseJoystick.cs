using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnpauserGameThenUseJoystick : MonoBehaviour
{
    [SerializeField] private FixedJoystick _fixedJoystick;
    [SerializeField] private PauserGame _pauserGame;

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