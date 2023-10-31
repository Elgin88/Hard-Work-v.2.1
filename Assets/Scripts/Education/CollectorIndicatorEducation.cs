using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorIndicatorEducation : MonoBehaviour
{
    [SerializeField] private GarageIndicatorEducation[] _garageIndicatorsEducation;
    [SerializeField] private Player _player;

    private void Start()
    {
        gameObject.SetActive(false);
        _player.Inventory.IsChangedNumberBlocks += OnCangedBlocksInPlayerInventory;
    }

    private void OnDisable()
    {
        _player.Inventory.IsChangedNumberBlocks -= OnCangedBlocksInPlayerInventory;
    }

    private void OnCangedBlocksInPlayerInventory(int current, int max)
    {
        if (current == 0)
        {
            foreach (var indicator in _garageIndicatorsEducation)
            {
                indicator?.gameObject.SetActive(true);
            }

            Destroy(gameObject);
        }
    }
}