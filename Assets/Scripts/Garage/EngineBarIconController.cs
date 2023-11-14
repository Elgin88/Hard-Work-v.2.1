using UnityEngine;

public class EngineBarIconController : MonoBehaviour
{
    [SerializeField] private EngineBarIconColorSetter _colorSetter1;
    [SerializeField] private EngineBarIconColorSetter _colorSetter2;
    [SerializeField] private EngineBarIconColorSetter _colorSetter3;
    [SerializeField] private float _maxDeltaScaleX;
    [SerializeField] private float _maxDeltaScaleY;
    [SerializeField] private float _maxDeltaScaleZ;
    [SerializeField] private float _duration;
    [SerializeField] private UIRequireComponents _UIRequireComponents;

    public float MaxScaleX => _maxDeltaScaleX;
    public float MaxScaleY => _maxDeltaScaleY;
    public float MaxScaleZ => _maxDeltaScaleZ;
    public float Duration => _duration;

    private void Start()
    {
        if (_colorSetter1 == null || _colorSetter2 == null || _colorSetter3 == null || _maxDeltaScaleX == 0 || _maxDeltaScaleY == 0 || _maxDeltaScaleZ == 0 || _duration == 0 || _UIRequireComponents == null)
        {
            Debug.Log("No serializefiel in " + gameObject.name);
        }
    }

    private void OnEnable()
    {
        _UIRequireComponents.PowerController.IsEngineUpgrade += OnUpgradeEngine;
    }

    private void OnDisable()
    {
        _UIRequireComponents.PowerController.IsEngineUpgrade -= OnUpgradeEngine;
    }

    private void OnUpgradeEngine(int level, bool isMaxLevel)
    {
        if (level == 1)
        {
            _colorSetter1.StartChangeColor();
        }
        else if (level == 2)
        {
            _colorSetter2.StartChangeColor();
        }
        else if (level == 3)
        {
            _colorSetter3.StartChangeColor();
        }
    }
}