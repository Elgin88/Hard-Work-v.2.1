using HardWork.Player;
using UnityEngine;

namespace HardWork.Collector
{
    [RequireComponent(typeof(Rigidbody))]

    public class CollectionParkingArea : MonoBehaviour
    {
        [SerializeField] private Collector _collector;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent<PlayerRam>(out PlayerRam destroyer))
            {
                if (_collector != null & destroyer.Inventory.GetCurrentCountOfBlocks() != 0)
                {
                    _collector.Unloader.StartUnload();
                }
            }
        }
    }
}