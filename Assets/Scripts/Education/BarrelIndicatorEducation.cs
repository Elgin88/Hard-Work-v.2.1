using System.Collections;
using UnityEngine;

public class BarrelIndicatorEducation : MonoBehaviour
{
    [SerializeField] private CollectorIndicatorEducation[] _collectorIndicators;
    [SerializeField] private ChooserMedals _chooserMedals;
    [SerializeField] private EnderLevel _enderLevel;
    [SerializeField] private Inventory _inventory;
    [SerializeField] private CalculatorBlocks _calculatorBlocks;

    private void Start()
    {
        _inventory.IsChangedNumberBlocks += OnChangedNumberBlocksOnPlayer;
    }

    private void OnDisable()
    {
        _inventory.IsChangedNumberBlocks -= OnChangedNumberBlocksOnPlayer;
    }

    private void OnChangedNumberBlocksOnPlayer(int current, int max)
    {
        if (current == max)
        {
            foreach (var indikator in _collectorIndicators)
            {
                if (indikator!=null)
                {
                    indikator.gameObject.SetActive(true);
                }                
            }

            Destroy(gameObject);
        }
    }
}