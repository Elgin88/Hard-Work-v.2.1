using UnityEngine;
using HardWork;

namespace HardWork
{
    public class GarageTrainingIndicator : MonoBehaviour
    {
        [SerializeField] private UIRequireComponents _UIRequireComponents;
        [SerializeField] private RequiredComponentsForPlayer _player;
        [SerializeField] private GarageParkingArea _garageParkingArea;
        [SerializeField] private AddFuelIndicatorEducation[] _addFuelButtonsEducation;
    }
}