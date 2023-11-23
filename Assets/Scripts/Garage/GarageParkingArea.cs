using UnityEngine;
using HardWork;

namespace HardWork
{
    public class GarageParkingArea : MonoBehaviour
    {
        [SerializeField] private Garage _garage;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent<PlayerRam>(out PlayerRam playerRam))
            {
                if (_garage != null)
                {
                    _garage.GarageUI.gameObject.SetActive(true);
                }

                if (playerRam.PlayerMoney.Money >= _garage.FuelCoust)
                {
                    foreach (var indicator in _garage.UIRequireComponents.AddFuelIndicators)
                    {
                        if (indicator != null)
                        {
                            indicator.gameObject.SetActive(true);
                        }
                    }
                }
            }
        }
    }
}