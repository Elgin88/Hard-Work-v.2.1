using UnityEngine;

namespace HardWork
{
    public class EntryPointBootstrap : MonoBehaviour
    {
        [SerializeField] private GameObject _SDK;

        private void Start()
        {
            EnableSDK();
        }

        private void EnableSDK()
        {
            _SDK.gameObject.SetActive(true);
        }
    }
}