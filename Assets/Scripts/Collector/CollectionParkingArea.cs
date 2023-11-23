using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class CollectionParkingArea : MonoBehaviour
{
    [SerializeField] private Collector _collector;

    private void Start()
    {
        if (_collector == null)
        {
            Debug.Log("No serializefiel in " + gameObject.name);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Destroyer>(out Destroyer destroyer))
        {
            if (_collector != null & destroyer.Inventory.GetCurrentCountOfBlocks() != 0)
            {
                _collector.Unloader.StartUnload();
            }
        }        
    }
}