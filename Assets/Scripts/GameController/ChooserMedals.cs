using UnityEngine;
using UnityEngine.Events;
using HardWork;

namespace HardWork
{
    public class ChooserMedals : MonoBehaviour
    {
        [SerializeField] private LevelCompletionConditionChecker _levelCompleter;
        [SerializeField] private CalculatorBlocks _calculatorBlocks;

        private bool _isMaxMedal = false;
        private bool _isMiddleMedal = false;
        private bool _isMinMedal = false;

        public event UnityAction<bool, bool, bool> IsMedalsChoosen;

        public bool IsMaxMedal => _isMaxMedal;

        public bool IsMiddleMedal => _isMiddleMedal;

        public bool IsMinMedal => _isMinMedal;

        public void ChooseMedals()
        {
            if (_calculatorBlocks.Unload >= _levelCompleter.MinNumberBlocks)
            {
                _isMinMedal = true;

                if (_calculatorBlocks.Unload >= _levelCompleter.MiddleNumberBlocks)
                {
                    _isMiddleMedal = true;

                    if (_calculatorBlocks.Unload == _levelCompleter.MaxNumberBlocks)
                    {
                        _isMaxMedal = true;
                    }
                }

                IsMedalsChoosen?.Invoke(_isMinMedal, _isMiddleMedal, _isMaxMedal);
            }
        }
    }
}