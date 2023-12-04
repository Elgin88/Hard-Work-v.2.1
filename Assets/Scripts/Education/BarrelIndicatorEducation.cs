using HardWork.Player;
using UnityEngine;

namespace HardWork.Education
{
    public class BarrelIndicatorEducation : MonoBehaviour
    {
        [SerializeField] private CollectorIndicatorEducation[] _collectorIndicators;
        [SerializeField] private PlayerInventory _inventory;

        private void Start()
        {
            _inventory.NumberBlocksIsChanged += OnChangedNumberBlocksOnPlayer;
        }

        private void OnChangedNumberBlocksOnPlayer(int current, int max)
        {
            if (current == max)
            {
                foreach (var indikator in _collectorIndicators)
                {
                    if (indikator != null)
                    {
                        indikator.gameObject.SetActive(true);
                    }
                }

                _inventory.NumberBlocksIsChanged -= OnChangedNumberBlocksOnPlayer;
                Destroy(gameObject);
            }
        }
    }
}