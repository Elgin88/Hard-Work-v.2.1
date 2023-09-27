using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerSpeedSetter))]
[RequireComponent(typeof(PlayerSoundController))]

public class PlayerMover : MonoBehaviour
{
    private FixedJoystick _joystick;
    private PlayerSpeedSetter _playerSpeedSetter;
    private Quaternion _currentPlayerDirection;
    private Coroutine _moveWork;
    private bool _isJoystickTurn;   

    public bool IsJoystickTurn => _isJoystickTurn;
    public Quaternion CurrentPlayerDirection => _currentPlayerDirection;
    public FixedJoystick Joystick => _joystick;
    private PlayerSoundController _playerSoundController;


    private void Start()
    {
        _joystick = FindObjectOfType<FixedJoystick>();        
        _playerSpeedSetter = GetComponent<PlayerSpeedSetter>();
        _playerSoundController = GetComponent<PlayerSoundController>();
        _isJoystickTurn = false;

        StartCoroutineMove();
    }

    private IEnumerator Move()
    {
        while (true)
        {
            if (_joystick != null)
            {
                if ((_joystick.Horizontal != 0) || (_joystick.Vertical != 0))
                {
                    _isJoystickTurn = true;
                    _currentPlayerDirection = Quaternion.LookRotation(new Vector3(_joystick.Horizontal, 0, _joystick.Vertical));
                    transform.rotation = _currentPlayerDirection;
                    transform.position = new Vector3(transform.position.x + _joystick.Horizontal * Time.deltaTime * _playerSpeedSetter.CurrentSpeed, transform.position.y, transform.position.z + _joystick.Vertical * Time.deltaTime * _playerSpeedSetter.CurrentSpeed);

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