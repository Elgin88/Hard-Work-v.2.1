using UnityEngine;
using HardWork;

namespace HardWork
{
    public class GarageTrainingIndicator : MonoBehaviour
    {
        [SerializeField] private RequireComponentsForUI _requireComponentsForUI;
        [SerializeField] private RequiredComponentsForPlayer _player;
        [SerializeField] private GarageParkingArea _garageParkingArea;
        [SerializeField] private AddFuelIndicatorEducation[] _addFuelButtonsEducation;
    }
}