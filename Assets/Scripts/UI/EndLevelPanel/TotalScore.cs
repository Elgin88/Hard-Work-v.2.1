using TMPro;
using UnityEngine;
using HardWork;

namespace HardWork
{
    public class TotalScore : MonoBehaviour
    {
        [SerializeField] private TMP_Text _label;
        [SerializeField] private UIRequireComponents _UIRequireComponents;

        private void Start()
        {
            if (_label == null || _UIRequireComponents == null)
            {
                Debug.Log("No serializefiel in " + gameObject.name);
            }
        }

        private void OnEnable()
        {
            _label.text = _UIRequireComponents.CalculatorBlocks.Unload.ToString();
        }
    }
}