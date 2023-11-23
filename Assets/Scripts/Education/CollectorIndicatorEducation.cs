using UnityEngine;
using HardWork;

namespace HardWork
{
    public class CollectorIndicatorEducation : MonoBehaviour
    {
        [SerializeField] private GarageTrainingIndicator[] _garageIndicatorsEducation;
        [SerializeField] private PlayerInventory _inventory;

        private void Start()
        {
            _inventory.NumberBlocksIsChanged += OnCangedBlocksInPlayerInventory;
        }

        private void OnDisable()
        {
            _inventory.NumberBlocksIsChanged -= OnCangedBlocksInPlayerInventory;
        }

        private void OnCangedBlocksInPlayerInventory(int current, int max)
        {
            if (current == 0)
            {
                foreach (var indicator in _garageIndicatorsEducation)
                {
                    if (indicator != null)
                    {
                        indicator.gameObject.SetActive(true);
                    }
                }

                Destroy(gameObject);
            }
        }
    }
}