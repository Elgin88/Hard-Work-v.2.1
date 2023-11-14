using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garage : MonoBehaviour
{
    [SerializeField] private int _fuelCost;
    [SerializeField] private int _tankCost;
    [SerializeField] private int _placeCost;
    [SerializeField] private int _powerCost;
    [SerializeField] private GarageUI _garageUI;
    [SerializeField] private UIRequireComponents _UIRequireComponents;

    public int FuelCoust => _fuelCost;
    public int TankCost => _tankCost;
    public int PlaceCost => _placeCost;
    public int PowerCost => _powerCost;
    public GarageUI GarageUI => _garageUI;
    public UIRequireComponents UIRequireComponents => _UIRequireComponents;

    private void Start()
    {
        if (_fuelCost == 0 || _tankCost == 0 || _placeCost == 0 || _powerCost == 0 || _garageUI == null || _UIRequireComponents == null)
        {
            Debug.Log("No serializefiel in " + gameObject.name);
        }
    }
}