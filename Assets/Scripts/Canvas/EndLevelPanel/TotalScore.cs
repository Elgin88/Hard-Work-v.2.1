using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TotalScore : MonoBehaviour
{
    [SerializeField] private TMP_Text _label;
    [SerializeField] private CanvasUI _canvasUI;    

    private void OnEnable()
    {
        _label.text = _canvasUI.CalculatorBlocks.Unload.ToString();
    }
}