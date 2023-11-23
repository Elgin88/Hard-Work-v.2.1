using Agava.WebUtility;
using UnityEngine;
using HardWork;

namespace HardWork
{
    public class BlockSound : MonoBehaviour
    {
        [SerializeField] private PlayerSoundController _playerSoundController;

        public void PlaySoundFlyOnCar()
        {
            if (_playerSoundController.BlockFly.isPlaying == false)
            {
                _playerSoundController.BlockFly.Play();
            }
        }

        public void PlayPlaceOnCar()
        {
            if (_playerSoundController.BlockFly.isPlaying == false)
            {
                _playerSoundController.BlockFly.Play();
            }
        }

        public void PlayFlyOnCollectorSFX()
        {
            if (_playerSoundController.BlockFlyToCollector.isPlaying == false)
            {
                _playerSoundController.BlockFlyToCollector.Play();
            }
        }

        public void PlayBlockPlaceInCollector()
        {
            if (_playerSoundController.BlockPlaceInCollector.isPlaying == false)
            {
                _playerSoundController.BlockPlaceInCollector.Play();
            }
        }
    }
}