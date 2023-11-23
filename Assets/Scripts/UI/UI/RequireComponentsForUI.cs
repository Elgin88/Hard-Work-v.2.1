using UnityEngine;
using HardWork;

namespace HardWork
{
    public class RequireComponentsForUI : MonoBehaviour
    {
        [SerializeField] private JoystickIndicatorEducation[] _joystickIndicators;
        [SerializeField] private AddFuelIndicatorEducation[] _addFuelIndicators;
        [SerializeField] private GarageUI _garageUI;
        [SerializeField] private SoundController _soundController;
        [SerializeField] private PlayerFuelController _playerFuelController;
        [SerializeField] private RequiredComponentsForPlayer _player;
        [SerializeField] private CalculatorBlocks _calculatorBlocks;
        [SerializeField] private ChooserMedals _chooserMedals;
        [SerializeField] private LevelCompletionConditionChecker _levelCompleter;
        [SerializeField] private Saver _saver;
        [SerializeField] private DestroyerPoint _destroyerPoint;
        [SerializeField] private GarageParkingArea _garageParkingArea;
        [SerializeField] private Garage _garage;
        [SerializeField] private GarageSoundController _garageSoundController;
        [SerializeField] private PlayerUpgrader _playerUpgrade;
        [SerializeField] private PlayerPowerController _playerPowerController;
        [SerializeField] private LineOfPoints _lineOfPoints;
        [SerializeField] private LineOfPointsCreater _lineOfPointsCreater;
        [SerializeField] private PlayerInventory _inventory;
        [SerializeField] private PauseSetter _pauseSetter;
        [SerializeField] private PlayerSpeedSetter _playerSpeedSetter;
        [SerializeField] private Advertising _advertising;
        [SerializeField] private PlayerMoney _playerMoney;
        [SerializeField] private ChooserLevelNameForLoad _chooserLevelNameForLoad;

        public RequiredComponentsForPlayer Player => _player;

        public JoystickIndicatorEducation[] JoystickIndicators => _joystickIndicators;

        public AddFuelIndicatorEducation[] AddFuelIndicators => _addFuelIndicators;

        public SoundController SoundController => _soundController;

        public GarageUI GarageUI => _garageUI;

        public PlayerFuelController PlayerFuelController => _playerFuelController;

        public CalculatorBlocks CalculatorBlocks => _calculatorBlocks;

        public ChooserMedals ChooserMedal => _chooserMedals;

        public LevelCompletionConditionChecker LevelCompleter => _levelCompleter;

        public Saver Saver => _saver;

        public DestroyerPoint DestroyerPoint => _destroyerPoint;

        public GarageParkingArea GarageParkingArea => _garageParkingArea;

        public Garage Garage => _garage;

        public GarageSoundController GarageSoundController => _garageSoundController;

        public PlayerUpgrader PlayerUpgrader => _playerUpgrade;

        public PlayerPowerController PowerController => _playerPowerController;

        public LineOfPoints LineOfPoints => _lineOfPoints;

        public LineOfPointsCreater LineOfPointsCreater => _lineOfPointsCreater;

        public PlayerInventory Inventory => _inventory;

        public PauseSetter PauseSetter => _pauseSetter;

        public PlayerSpeedSetter PlayerSpeedSetter => _playerSpeedSetter;

        public Advertising Advertising => _advertising;

        public PlayerMoney PlayerMoney => _playerMoney;

        public ChooserLevelNameForLoad ChooserLevelNameForLoad => _chooserLevelNameForLoad;
    }
}