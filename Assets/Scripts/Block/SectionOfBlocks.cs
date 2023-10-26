using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]

public class SectionOfBlocks : MonoBehaviour
{
    [SerializeField] private Block [] _blocks;
    [SerializeField] private Player _player;

    private Coroutine _activeBlocks;
    private int _requireNumberActiveBlocks = 3;
    private int _numberActiveBlocks = 0;

    public int NumberOfBlocks => _blocks.Length;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Destroyer>(out Destroyer destroyer))
        {
            StartActiveBlocks();
            _player.SoundController.PlayObjectDestractionSound();
        }
    }

    private IEnumerator ActiveBlocks()
    {
        while (true)
        {
            foreach (Block block in _blocks)
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

            gameObject.SetActive(false);
            StopActiveBlocks();
            yield return null;
        }
    }

    public void StartActiveBlocks()
    {
        if (_activeBlocks==null)
        {
            _activeBlocks = StartCoroutine(ActiveBlocks());
        }
    }

    public void StopActiveBlocks()
    {
        if (_activeBlocks!=null)
        {
            StopCoroutine(_activeBlocks);
            _activeBlocks = null;
        }
    }
}