using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnpauserGameThenUseJoystick : MonoBehaviour
{
    [SerializeField] private FixedJoystick _fixedJoystick;
    [SerializeField] private PauserGame _pauserGame;

    private void Start()
    {
        if (_fixedJoystick == null || _pauserGame == null)
        {
            Debug.Log("No serializefiel in " + gameObject.name);
        }
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