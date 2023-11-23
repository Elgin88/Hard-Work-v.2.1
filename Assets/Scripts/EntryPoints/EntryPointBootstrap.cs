using UnityEngine;
using HardWork;

namespace HardWork
{
    public class EntryPointBootstrap : MonoBehaviour
    {
        [SerializeField] private GameObject _SDK;

        private void Start()
        {
            InitSDK();
        }

        private void InitSDK()
        {
            _SDK.gameObject.SetActive(true);
        }
    }
}