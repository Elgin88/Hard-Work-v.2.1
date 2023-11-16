using System.Collections;
using UnityEngine;

public class SectionOfBlocks : MonoBehaviour
{
    [SerializeField] private Block [] _blocks;
    [SerializeField] private PlayerSoundController _playerSoundController;

    private Coroutine _activeBlocks;
    private int _requireNumberActiveBlocks = 3;
    private int _numberActiveBlocks = 0;

    public int NumberOfBlocks => _blocks.Length;

    private void Start()
    {
        if (_blocks == null || _playerSoundController == null)
        {
            Debug.Log("No serializefiel in " + gameObject.name);
        }
    }

    public void StartActiveBlocks()
    {
        if (_activeBlocks == null)
        {
            _activeBlocks = StartCoroutine(ActiveBlocks());
        }
    }

    public void StopActiveBlocks()
    {
        if (_activeBlocks != null)
        {
            StopCoroutine(_activeBlocks);
            _activeBlocks = null;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Destroyer>(out Destroyer destroyer))
        {
            StartActiveBlocks();
            _playerSoundController.PlayObjectDestractionSound();
        }
    }

    private IEnumerator ActiveBlocks()
    {
        while (true)
        {
            foreach (Block block in _blocks)
            {
                if (block!=null)
                {
                    block.gameObject.SetActive(true);
                    block.StartTimerPhysicsOff();

                    _numberActiveBlocks++;

                    if (_numberActiveBlocks > _requireNumberActiveBlocks)
                    {
                        yield return null;
                        _numberActiveBlocks = 0;
                    }
                }
            }

            gameObject.SetActive(false);
            StopActiveBlocks();

            yield return null;
        }
    }
}