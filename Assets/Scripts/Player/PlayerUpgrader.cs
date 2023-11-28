using UnityEngine;

namespace HardWork
{
    public class PlayerUpgrader : MonoBehaviour
    {
        [SerializeField] private int _deltaMaxFuel;
        [SerializeField] private int _deltaMaxLines;
        [SerializeField] private float _deltaPower;

        private PlayerPowerController _powerController;
        private PlayerFuelController _fuelController;
        private LineOfPointsCreater _lineOfPointsCreater;
        private Garage _garage;

        private void Start()
        {
            _fuelController = GetComponent<PlayerFuelController>();
            _powerController = GetComponent<PlayerPowerController>();

            _lineOfPointsCreater = FindObjectOfType<LineOfPointsCreater>();
        }

        public void BuyFuel()
        {
            _fuelController.BuyFuel();
            _fuelController.InitActionChangeFuel();
        }

        public void BuyTank()
        {
            _fuelController.BuyTank(_deltaMaxFuel);
        }

        public void AddPlace()
        {
            _lineOfPointsCreater.AddPlace(_deltaMaxLines);
        }

        public void AddPower()
        {
            _powerController.AddPower(_deltaPower);
        }
    }
}