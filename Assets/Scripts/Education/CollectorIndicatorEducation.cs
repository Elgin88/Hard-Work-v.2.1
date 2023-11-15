using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorIndicatorEducation : MonoBehaviour
{
    [SerializeField] private GarageIndicatorEducation [] _garageIndicatorsEducation;
    [SerializeField] private PlayerInventory _inventory;

    private void Start()
    {
        _inventory.IsChangedNumberBlocks += OnCangedBlocksInPlayerInventory;
    }

    private void OnDisable()
    {
        _inventory.IsChangedNumberBlocks -= OnCangedBlocksInPlayerInventory;
    }

    private void OnCangedBlocksInPlayerInventory(int current, int max)
    {
        if (current == 0)
        {
            foreach (var indicator in _garageIndicatorsEducation)
            {
                if (indicator!=null)
                {
                    indicator.gameObject.SetActive(true);
                }                
            }

            Destroy(gameObject);
        }
    }
}