using UnityEngine;
using HardWork;

namespace HardWork
{
    public class IndicatorsEducation : MonoBehaviour
    {
        [SerializeField] private BarrelIndicatorEducation[] _barrelIndicatorsEducation;
        [SerializeField] private CollectorIndicatorEducation[] _collectorIndicatorsEducation;
        [SerializeField] private GarageTrainingIndicator[] _garageIndicatorsEducation;
        [SerializeField] private JoystickIndicatorEducation[] _joystickIndicatorEducation;

        public BarrelIndicatorEducation[] BarrelIndicators => _barrelIndicatorsEducation;
        public CollectorIndicatorEducation[] CollectorIndicatorsEducation => _collectorIndicatorsEducation;
        public GarageTrainingIndicator[] GarageIndicatorsEducation => _garageIndicatorsEducation;

        private void Start()
        {
            foreach (var item in _joystickIndicatorEducation)
            {
                item.gameObject.SetActive(true);
            }
        }
    }
}