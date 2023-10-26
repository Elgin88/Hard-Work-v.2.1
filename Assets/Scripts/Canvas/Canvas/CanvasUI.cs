using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasUI : MonoBehaviour
{
    [SerializeField] private JoystickIndicatorEducation[] _joystickIndicators;
    [SerializeField] private AddFuelIndicatorEducation[] _addFuelIndicators;
    [SerializeField] private EndLevelButtonIndicatorEducation[] _endLevelButtonIndicatorEducation;
    [SerializeField] private GarageUI _garageUI;
   
    [SerializeField] SoundController _soundController;

    private PlayerFuelController _playerFuelController;
    private Player _player;
    private VideoAdController _videoAddController;

    public Player Player => _player;

    public JoystickIndicatorEducation[] JoystickIndicators => _joystickIndicators;
    public AddFuelIndicatorEducation[] AddFuelIndicators => _addFuelIndicators;
    public EndLevelButtonIndicatorEducation[] EndLevelButtonIndicatorEducation => _endLevelButtonIndicatorEducation;
    public VideoAdController VideoAddController => _videoAddController;
    public SoundController SoundController => _soundController;
    public GarageUI GarageUI => _garageUI;

    private void Start()
    {
        _playerFuelController = FindObjectOfType<PlayerFuelController>();
        _player = FindObjectOfType<Player>();
        _videoAddController = FindObjectOfType<VideoAdController>();
    }
}