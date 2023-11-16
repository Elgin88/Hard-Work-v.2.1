using System;
using System.Collections;
using UnityEngine;

public class CalculatorBlocks : MonoBehaviour
{
    private SectionOfBlocks[] _allSections;
    private Block [] _freeBlocks;
    private int _allBlocksInSections;
    private int _numberUnloadBlocks;
    private int _allBlocks;
    private int _numberBlocksOnCar;

    public Action <int> NumberUnloadBlocksIsChanged;
    public int AllBlocks => _allBlocks;
    public int Unload => _numberUnloadBlocks;

    private void Start()
    {
        StartCoroutine(CalculateBlocks());
    }

    public void CalculateUnloadBloks()
    {
        _numberUnloadBlocks++;
        NumberUnloadBlocksIsChanged?.Invoke(_numberUnloadBlocks);
    }

    private IEnumerator CalculateBlocks()
    {
        _allSections = FindObjectsOfType<SectionOfBlocks>();

        foreach (SectionOfBlocks section in _allSections)
        {
            _allBlocksInSections += section.NumberOfBlocks;
        }

        _allBlocks = _allBlocksInSections;

        StopCoroutine(CalculateBlocks());

        yield return null;
    }
}