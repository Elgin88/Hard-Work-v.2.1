using UnityEngine;

namespace HardWork
{
    public class EndLevelPanel : MonoBehaviour
    {
        [SerializeField] private MinMedal _minMedal;
        [SerializeField] private MiddleMedal _middleMedal;
        [SerializeField] private MaxMedal _maxMedal;
        [SerializeField] private RequireComponentsForUI _requireComponentsForUI;

        private void OnEnable()
        {
            OpenPanels(_requireComponentsForUI.ChooserMedal.IsMinMedal, _requireComponentsForUI.ChooserMedal.IsMiddleMedal, _requireComponentsForUI.ChooserMedal.IsMaxMedal);

            _requireComponentsForUI.ChooserMedal.IsMedalsChoosen += OnMedalsChoosen;
        }

        private void OnDisable()
        {
            _requireComponentsForUI.ChooserMedal.IsMedalsChoosen -= OnMedalsChoosen;
        }

        private void OnMedalsChoosen(bool isMin, bool isMiddle, bool isMax)
        {
            OpenPanels(isMin, isMiddle, isMax);
        }

        private void OpenPanels(bool isMin, bool isMiddle, bool isMax)
        {
            bool isMinEnabled = false;
            bool isMiddleEnabled = false;
            bool isMaxEnabled = false;

            if (isMin == true & isMinEnabled == false)
            {
                _minMedal.gameObject.SetActive(true);
                isMinEnabled = true;
            }

            if (isMiddle == true & isMiddleEnabled == false)
            {
                _middleMedal.gameObject.SetActive(true);
                isMiddleEnabled = true;
            }

            if (isMax == true & isMaxEnabled == false)
            {
                _maxMedal.gameObject.SetActive(true);
                isMaxEnabled = true;
            }
        }
    }
}