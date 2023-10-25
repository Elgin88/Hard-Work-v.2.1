using UnityEngine;

[RequireComponent(typeof(Block))]

public class BlockSoundController : MonoBehaviour
{
    [SerializeField] private PlayerSoundController _playerSoundController;

    private AudioSource _audioSourseBlockFlyOnCar;
    private AudioSource _audioSourseBlockSetOnCar;
    private AudioSource _ausioSourseBlockFlyToCollector;
    private AudioSource _audioSourseBlockPlaceInCollector;

    private void Start()
    {
        _audioSourseBlockFlyOnCar = _playerSoundController.BlockFly;
        _audioSourseBlockSetOnCar = _playerSoundController.BlockSetOnCar;
        _ausioSourseBlockFlyToCollector = _playerSoundController.BlockFlyToCollerctor;
        _audioSourseBlockPlaceInCollector = _playerSoundController.BlockPlaceInCollector;
    }

    public void InitSoundController(PlayerSoundController playerSoundController)
    {

    }

    public void PlayFlyOnCarSFX()
    {
        if (_audioSourseBlockFlyOnCar.isPlaying == false)
        {
            _audioSourseBlockFlyOnCar.Play();
        }        
    }

    public void PlayPlaceOnCarSFX()
    {
        if (_audioSourseBlockSetOnCar.isPlaying == false)
        {
            _audioSourseBlockSetOnCar.Play();
        }        
    }

    public void PlayFlyOnCollectorSFX()
    {
        if (_ausioSourseBlockFlyToCollector.isPlaying == false)
        {
            _ausioSourseBlockFlyToCollector.Play();
        }
    }

    public void PlayBlockPlaceInCollector()
    {
        if (_audioSourseBlockPlaceInCollector.isPlaying==false)
        {
            _audioSourseBlockPlaceInCollector.Play();
        }
    }
}