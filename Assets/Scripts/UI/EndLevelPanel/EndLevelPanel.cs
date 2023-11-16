using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevelPanel : MonoBehaviour
{
    [SerializeField] private MinMedal _minMedal;
    [SerializeField] private MiddleMedal _middleMedal;
    [SerializeField] private MaxMedal _maxMedal;
    [SerializeField] private UIRequireComponents _UIRequireComponents;

    private void Start()
    {
        if (_minMedal == null || _middleMedal == null || _maxMedal == null || _UIRequireComponents == null)
        {
            Debug.Log("No serializefiel in " + gameObject.name);
        }
    }

    private void OnEnable()
    {
        OpenPanels(_UIRequireComponents.ChooserMedal.IsMinMedal, _UIRequireComponents.ChooserMedal.IsMiddleMedal, _UIRequireComponents.ChooserMedal.IsMaxMedal);

        _UIRequireComponents.ChooserMedal.IsMedalsChoosen += OnMedalsChoosen;
    }

    private void OnDisable()
    {
        _UIRequireComponents.ChooserMedal.IsMedalsChoosen -= OnMedalsChoosen;
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