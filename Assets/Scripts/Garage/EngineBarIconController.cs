using HardWork.UI;
using UnityEngine;

namespace HardWork.Garage
{
    public class EngineBarIconController : MonoBehaviour
    {
        [SerializeField] private EngineBarIconColorSetter _colorSetter1;
        [SerializeField] private EngineBarIconColorSetter _colorSetter2;
        [SerializeField] private EngineBarIconColorSetter _colorSetter3;
        [SerializeField] private RequireComponentsForUI _requireComponentsForUI;

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