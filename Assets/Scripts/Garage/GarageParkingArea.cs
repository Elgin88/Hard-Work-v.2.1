using HardWork.Player;
using UnityEngine;

namespace HardWork.Garage
{
    public class GarageParkingArea : MonoBehaviour
    {
        [SerializeField] private GarageMain _garage;

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
                    foreach (var indicator in _garage.RequireComponentsForUI.AddFuelIndicators)
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