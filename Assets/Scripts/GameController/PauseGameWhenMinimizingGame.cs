using System.Collections;
using UnityEngine;

public class PauseGameWhenMinimizingGame : MonoBehaviour
{
    [SerializeField] private PauserGame _pauserGame;


    private void Update()
    {
#if UNITY_EDITOR
        return;
#endif

#if UNITY_WEBGL
        if (Agava.WebUtility.WebApplication.InBackground)
        {
            _pauserGame.PauseOn();
        }
#endif
    }
}