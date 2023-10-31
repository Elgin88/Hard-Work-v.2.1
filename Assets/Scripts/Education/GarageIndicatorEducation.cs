using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GarageIndicatorEducation : MonoBehaviour
{
    [SerializeField] private CanvasUI _canvasUI;

    private string _level1Name = "Level1";  
    private AddFuelIndicatorEducation[] _addFuelIndicator => _canvasUI.AddFuelIndicators;

    private void Start()
    {
        gameObject.SetActive(false);
    }
}