using System;
using System.Collections;
using UnityEngine;

namespace HardWork
{
    public class CalculatorBlocks : MonoBehaviour
    {
        [SerializeField] private SectionOfBlocks[] _allSections;

        private Block[] _freeBlocks;
        private int _allBlocksInSections;
        private int _numberUnloadBlocks;
        private int _allBlocks;
        private int _numberBlocksOnCar;

        public Action <int> NumberUnloadBlocksIsChanged;

        public int AllBlocks => _allBlocks;

        public int Unload => _numberUnloadBlocks;

        public void CalculateUnloadBloks()
        {
            _numberUnloadBlocks++;
            NumberUnloadBlocksIsChanged?.Invoke(_numberUnloadBlocks);
        }

        private void Start()
        {
            StartCoroutine(CalculateBlocks());
        }

        private IEnumerator CalculateBlocks()
        {
            foreach (SectionOfBlocks section in _allSections)
            {
                _allBlocksInSections += section.NumberOfBlocks;
            }

            _allBlocks = _allBlocksInSections;

            StopCoroutine(CalculateBlocks());

            yield return null;
        }
    }
}