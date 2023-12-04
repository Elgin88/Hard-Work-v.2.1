using HardWork.Empty;
using HardWork.Garage;
using HardWork.SaverAndLoader;
using UnityEngine;

namespace HardWork.Player
{
    [RequireComponent(typeof(PlayerMover))]
    [RequireComponent(typeof(PlayerFuelController))]
    [RequireComponent(typeof(PlayerMover))]
    [RequireComponent(typeof(PlayerPowerController))]
    [RequireComponent(typeof(PlayerSpeedSetter))]
    [RequireComponent(typeof(PlayerUpgrader))]
    [RequireComponent(typeof(PlayerSoundController))]
    [RequireComponent(typeof(PlayerMoney))]

    public class RequiredComponentsForPlayer : MonoBehaviour
    {
        [SerializeField] private GarageMain _garage;
        [SerializeField] private CollectorPoint _collectorPoint;
        [SerializeField] private FixedJoystick _fixedJoystick;
        [SerializeField] private Loader _loader;

        public CollectorPoint CollectorPoint => _collectorPoint;

        public FixedJoystick FixedJoystick => _fixedJoystick;

        public GarageMain Garage => _garage;

        public Loader Loader => _loader;
    }
}