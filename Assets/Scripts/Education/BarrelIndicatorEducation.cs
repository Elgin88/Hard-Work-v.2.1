using System.Collections;
using UnityEngine;

public class BarrelIndicatorEducation : MonoBehaviour
{
    [SerializeField] private CollectorIndicatorEducation[] _collectorIndicators;
    [SerializeField] private ChooserMedals _chooserMedals;
    [SerializeField] private EnderLevel _enderLevel;
    [SerializeField] private Inventory _inventory;
    [SerializeField] private CalculatorBlocks _calculatorBlocks;

    private float _deltaScaleInPercentages = 30;
    private float _timeOfFlashInSeconds = 0.3f;
    private Coroutine _flash;
    private Vector3 _startScale;
    private Vector3 _currentScale;
    private Vector3 _targetScale;
    private float _deltaScale => (_targetScale.x - _startScale.x) / (_timeOfFlashInSeconds / Time.deltaTime);

    private void Start()
    {
        gameObject.SetActive(false);
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
                if (indikator !=null)
                {
                    indikator.gameObject.SetActive(true);
                }
            }

            Destroy(gameObject);
        }
    }
}