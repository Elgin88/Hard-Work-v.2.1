using UnityEngine;
using HardWork;

namespace HardWork
{
    public class Collector : MonoBehaviour
    {
        [SerializeField] private Unloader _unloader;
        [SerializeField] private RequiredComponentsForPlayer _player;

        public RequiredComponentsForPlayer Player => _player;

        public Unloader Unloader => _unloader;
    }
}