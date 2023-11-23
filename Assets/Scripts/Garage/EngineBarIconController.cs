using UnityEngine;
using HardWork;

namespace HardWork
{
    public class EngineBarIconController : MonoBehaviour
    {
        [SerializeField] private EngineBarIconColorSetter _colorSetter1;
        [SerializeField] private EngineBarIconColorSetter _colorSetter2;
        [SerializeField] private EngineBarIconColorSetter _colorSetter3;
        [SerializeField] private float _maxDeltaScaleX;
        [SerializeField] private float _maxDeltaScaleY;
        [SerializeField] private float _maxDeltaScaleZ;
        [SerializeField] private float _duration;
        [SerializeField] private RequireComponentsForUI _requireComponentsForUI;

        public float MaxScaleX => _maxDeltaScaleX;

        public float MaxScaleY => _maxDeltaScaleY;

        public float MaxScaleZ => _maxDeltaScaleZ;

        public float Duration => _duration;

        private void OnEnable()
        {
            _requireComponentsForUI.PowerController.IsEngineUpgraded += OnUpgradeEngine;
        }

        private void OnDisable()
        {
            _requireComponentsForUI.PowerController.IsEngineUpgraded -= OnUpgradeEngine;
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
}