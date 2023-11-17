using UnityEngine;

public class UIRequireComponents : MonoBehaviour
{
    [SerializeField] private JoystickIndicatorEducation[] _joystickIndicators;
    [SerializeField] private AddFuelIndicatorEducation[] _addFuelIndicators;
    [SerializeField] private GarageUI _garageUI;   
    [SerializeField] private SoundController _soundController;
    [SerializeField] private PlayerFuelController _playerFuelController;
    [SerializeField] private PlayerRequireComponents _player;
    [SerializeField] private CalculatorBlocks _calculatorBlocks;
    [SerializeField] private EnderLevel _endelLevel;
    [SerializeField] private ChooserMedals _chooserMedals;
    [SerializeField] private EnderLevel _enderLevel;
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
    [SerializeField] private PauserGame _pauserGame;
    [SerializeField] private PlayerSpeedSetter _playerSpeedSetter;
    [SerializeField] private Advertising _advertising;
    [SerializeField] private PlayerMoney _playerMoney;
    [SerializeField] private ChooserLevelNameForLoad _chooserLevelNameForLoad;

    public PlayerRequireComponents Player => _player;
    public JoystickIndicatorEducation[] JoystickIndicators => _joystickIndicators;
    public AddFuelIndicatorEducation[] AddFuelIndicators => _addFuelIndicators;
    public SoundController SoundController => _soundController;
    public GarageUI GarageUI => _garageUI;
    public PlayerFuelController PlayerFuelController => _playerFuelController;
    public CalculatorBlocks CalculatorBlocks => _calculatorBlocks;
    public EnderLevel EndelLevel => _endelLevel;
    public ChooserMedals ChooserMedal => _chooserMedals;
    public EnderLevel EnderLevel => _endelLevel;
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
    public PauserGame PauserGame => _pauserGame;
    public PlayerSpeedSetter PlayerSpeedSetter => _playerSpeedSetter;
    public Advertising Advertising => _advertising;
    public PlayerMoney PlayerMoney => _playerMoney;
    public ChooserLevelNameForLoad ChooserLevelNameForLoad => _chooserLevelNameForLoad;

    private void Start()
    {
        if (_joystickIndicators == null ||
            _addFuelIndicators == null ||
            _soundController == null ||
            _garageUI == null ||
            _soundController == null ||
            _playerFuelController == null ||
            _player == null ||
            _calculatorBlocks == null ||
            _endelLevel == null ||
            _chooserMedals == null ||
            _enderLevel == null ||
            _saver == null ||
            _destroyerPoint == null ||
            _garageParkingArea == null ||
            _garage == null ||
            _garageSoundController == null ||
            _playerUpgrade == null ||
            _playerPowerController == null ||
            _lineOfPoints == null ||
            _lineOfPointsCreater == null ||
            _inventory == null ||
            _pauserGame == null ||
            _playerSpeedSetter == null||
            _advertising == null ||
            _playerMoney == null ||
            _chooserLevelNameForLoad == null)
        {
            Debug.Log("No serializefiel in " + gameObject.name);
        }
    }
}