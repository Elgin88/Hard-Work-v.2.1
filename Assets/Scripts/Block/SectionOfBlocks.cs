using UnityEngine;

[RequireComponent(typeof(BoxCollider))]

public class SectionOfBlocks : MonoBehaviour
{
    [SerializeField] private Block [] _blocks;

    private Player _player;
    private int _numberOfBlocks;

    public int NumberOfBlocks => _blocks.Length;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Destroyer>(out Destroyer destroyer))
        {
            _player = destroyer.Player;

            foreach (Block block in _blocks)
            {
                block.gameObject.SetActive(true);                
                block.Init(_player);
            }

            _player.PlayerSoundController.PlayObjectDestractionSound();

            gameObject.SetActive(false);
        }
    }

}