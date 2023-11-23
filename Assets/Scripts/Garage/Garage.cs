using UnityEngine;
using HardWork;

namespace HardWork
{
    public class Garage : MonoBehaviour
    {
        [SerializeField] private int _fuelCost;
        [SerializeField] private int _tankCost;
        [SerializeField] private int _placeCost;
        [SerializeField] private int _powerCost;
        [SerializeField] private GarageUI _garageUI;
        [SerializeField] private RequireComponentsForUI _requireComponentsForUI;

        public RequireComponentsForUI RequireComponentsForUI => _requireComponentsForUI;

        public GarageUI GarageUI => _garageUI;

        public int FuelCoust => _fuelCost;

        public int PlaceCost => _placeCost;

        public int PowerCost => _powerCost;

        public int TankCost => _tankCost;
    }
}