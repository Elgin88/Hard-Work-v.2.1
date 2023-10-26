using UnityEngine;

public class BlockSoundController : MonoBehaviour
{
    [SerializeField] private PlayerSoundController _playerSoundController;

    public void PlayFlyOnCarSFX()
    {
        if (_playerSoundController.BlockFly.isPlaying == false)
        {
            _playerSoundController.BlockFly.Play();
        }        
    }

    public void PlayPlaceOnCarSFX()
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
        if (_playerSoundController.BlockPlaceInCollector.isPlaying==false)
        {
            _playerSoundController.BlockPlaceInCollector.Play();
        }
    }
}