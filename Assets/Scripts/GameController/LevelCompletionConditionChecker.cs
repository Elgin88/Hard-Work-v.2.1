using UnityEngine;

namespace HardWork
{
    public class LevelCompletionConditionChecker : MonoBehaviour
    {
        [SerializeField] private EndLevelButton _endLevelButton;
        [SerializeField] private ReloadButton _reloadButton;
        [SerializeField] private EndLevelPanel _endLevelPanel;
        [SerializeField] private CalculatorBlocks _calculatorBlocks;
        [SerializeField] private ChooserMedals _chooserMedals;

        private int _maxProcent = 95;
        private int _middleProcent = 80;
        private int _minProcent = 60;
        private int _allBlocks;
        private int _middleNumberBlocks;
        private int _minNumberBlocks => _allBlocks * _minProcent / 100;

        public int MaxNumberBlocks => _allBlocks;

        public int MiddleNumberBlocks => _middleNumberBlocks;

        public int MinNumberBlocks => _minNumberBlocks;

        public int MaxProcent => _maxProcent;

        public int MiddleProcent => _middleProcent;

        public int MinProcent => _minProcent;

        private void OnEnable()
        {
            _calculatorBlocks.NumberUnloadBlocksIsChanged += OnChangedNumberUnloadBlocks;
        }

        private void OnDisable()
        {
            _calculatorBlocks.NumberUnloadBlocksIsChanged -= OnChangedNumberUnloadBlocks;
        }

        private void OnChangedNumberUnloadBlocks(int unloadBlocks)
        {
            if (_allBlocks == 0)
            {
                _allBlocks = _calculatorBlocks.AllBlocks;
                _middleNumberBlocks = _allBlocks * _middleProcent / 100;
            }

            if (unloadBlocks >= _minNumberBlocks)
            {
                _reloadButton.gameObject.SetActive(false);
                _endLevelButton.gameObject.SetActive(true);

                if (unloadBlocks == _allBlocks)
                {
                    _endLevelPanel.gameObject.SetActive(true);
                }
            }
        }
    }
}