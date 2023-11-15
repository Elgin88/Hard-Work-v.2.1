using System;
using System.Collections;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private PlayerRequireComponents _playerRequreComponents;
    [SerializeField] private PlayerSpeedSetter _playerSpeedSetter;
    [SerializeField] private PlayerSoundController _playerSoundController;

    private Quaternion _currentPlayerDirection;
    private Coroutine _moveWork;
    private bool _isJoystickTurn;

    public Quaternion CurrentPlayerDirection => _currentPlayerDirection;
    public bool IsJoystickTurn => _isJoystickTurn;
    public Action IsPushed;

    private void Start()
    {
        if (_playerRequreComponents == null || _playerSpeedSetter == null || _playerSoundController == null)
        {
            Debug.Log("No serializefield in " + gameObject.name);
        }

        _isJoystickTurn = false;

        StartCoroutineMove();
    }

    private IEnumerator Move()
    {
        while (true)
        {
            if (_playerRequreComponents.FixedJoystick != null)
            {
                if ((_playerRequreComponents.FixedJoystick.Horizontal != 0) || (_playerRequreComponents.FixedJoystick.Vertical != 0))
                {
                    _isJoystickTurn = true;
                    _currentPlayerDirection = Quaternion.LookRotation(new Vector3(_playerRequreComponents.FixedJoystick.Horizontal, 0, _playerRequreComponents.FixedJoystick.Vertical));
                    transform.rotation = _currentPlayerDirection;
                    transform.position = new Vector3(transform.position.x + _playerRequreComponents.FixedJoystick.Horizontal * Time.deltaTime * _playerSpeedSetter.CurrentSpeed, transform.position.y, transform.position.z + _playerRequreComponents.FixedJoystick.Vertical * Time.deltaTime * _playerSpeedSetter.CurrentSpeed);

                    _playerSoundController.StopMinEngineSound();
                    _playerSoundController.PlayMaxEngineSound();
                }
                else
                {
                    _isJoystickTurn = false;

                    _playerSoundController.StopMaxEngineSound();
                    _playerSoundController.PlayMinEngineSound();
                }
            }

            yield return null;
        }
    }

    public void SlowDown()
    {
        IsPushed.Invoke();
    }

    public void StartCoroutineMove()
    {
        if (_moveWork == null)
        {
            _moveWork = StartCoroutine(Move());
        }
    }

    public void StopCoroutineMove()
    {
        if (_moveWork != null)
        {
            StopCoroutine(_moveWork);
            _moveWork = null;
        }
    }
}	