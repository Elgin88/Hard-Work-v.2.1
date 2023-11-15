using UnityEngine;

public class PlayerDestroyerTakeDamagePoint : MonoBehaviour
{
    [SerializeField] private PlayerSoundController _playerSoundController;
    [SerializeField] private ParticleSystem _particle;

    private WaitForSeconds _pauseWFS;
    private Coroutine _pause;

    private void Start()
    {
        if (_playerSoundController == null || _particle == null)
        {
            Debug.Log("No serializefiel in " + gameObject.name);
        }
    }

    private void OnEnable()
    {
        if (_particle!=null)
        {
            _particle.gameObject.SetActive(false);
        }        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Block>(out Block block) || collision.gameObject.TryGetComponent<SectionOfBlocks>(out SectionOfBlocks section))
        {
            _particle.gameObject.SetActive(true);
            _particle.Play();
            _playerSoundController.PlayBlockHitBumberSound();
        }
    }    
}