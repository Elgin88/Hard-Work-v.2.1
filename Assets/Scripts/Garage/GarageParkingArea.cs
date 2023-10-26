using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarageParkingArea : MonoBehaviour
{
    [SerializeField] private Garage _garage;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Destroyer>(out Destroyer destroyer))
        {
            _garage.GarageUI.gameObject.SetActive(true);

            if (destroyer.Player.Money >= _garage.FuelCoust)
            {
                foreach (var indicator in _garage.CanvasUI.AddFuelIndicators)
                {
                    indicator.gameObject.SetActive(true);
                }
            }            
        }
    }
}