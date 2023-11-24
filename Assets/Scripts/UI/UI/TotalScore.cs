using TMPro;
using UnityEngine;

namespace HardWork
{
    public class TotalScore : MonoBehaviour
    {
        [SerializeField] private TMP_Text _label;
        [SerializeField] private RequireComponentsForUI _requireComponentsForUI;

        private void OnEnable()
        {
            _label.text = _requireComponentsForUI.CalculatorBlocks.Unload.ToString();
        }
    }
}