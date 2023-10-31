using UnityEngine;

public class GarageParkingArea : MonoBehaviour
{
    [SerializeField] private Garage _garage;

    private void Start()
    {
        if (_garage == null)
        {
            Debug.Log("No serializefiel in " + gameObject.name);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Destroyer>(out Destroyer destroyer))
        {
            if (_garage!=null)
            {
                _garage.GarageUI.gameObject.SetActive(true);
            }            

            if (destroyer.Player.Money >= _garage.FuelCoust)
            {
                foreach (var indicator in _garage.CanvasUI.AddFuelIndicators)
                {
                    indicator.gameObject.SetActive(true);
                }
            }            
        }
    }
}