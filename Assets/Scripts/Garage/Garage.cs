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
    [SerializeField] private CanvasUI _canvasUI;

    public int FuelCoust => _fuelCost;
    public int TankCost => _tankCost;
    public int PlaceCost => _placeCost;
    public int PowerCost => _powerCost;
    public GarageUI GarageUI => _garageUI;
    public CanvasUI CanvasUI => _canvasUI;

    private void Start()
    {
        if (_fuelCost == 0 || _tankCost == 0 || _placeCost == 0 || _powerCost == 0 || _garageUI == null || _canvasUI == null)
        {
            Debug.Log("No serializefiel in " + gameObject.name);
        }
    }
}