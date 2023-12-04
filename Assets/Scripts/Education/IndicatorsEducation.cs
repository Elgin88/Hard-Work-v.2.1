using UnityEngine;

namespace HardWork.Education
{
    public class IndicatorsEducation : MonoBehaviour
    {
        [SerializeField] private GarageTrainingIndicator[] _garageIndicatorsEducation;
        [SerializeField] private JoystickIndicatorEducation[] _joystickIndicatorEducation;

        private void Start()
        {
            foreach (var item in _joystickIndicatorEducation)
            {
                item.gameObject.SetActive(true);
            }
        }

        public void GarageIndicatorsEducationEnable()
        {
            foreach (var indicator in _garageIndicatorsEducation)
            {
                indicator.gameObject.SetActive(true);
            }
        }

        public void GarageIndicatorsEducationDisable()
        {
            foreach (var indicator in _garageIndicatorsEducation)
            {
                indicator.gameObject.SetActive(false);
            }
        }
    }
}