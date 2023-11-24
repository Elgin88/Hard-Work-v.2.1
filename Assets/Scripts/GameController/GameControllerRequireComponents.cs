using UnityEngine;

namespace HardWork
{
    [RequireComponent(typeof(CalculatorBlocks))]
    [RequireComponent(typeof(LevelCompletionConditionChecker))]
    [RequireComponent(typeof(ChooserMedals))]
    [RequireComponent(typeof(SoundOffWhenMinimizingGame))]
    [RequireComponent(typeof(SoundController))]
    [RequireComponent(typeof(Saver))]
    [RequireComponent(typeof(Loader))]
    [RequireComponent(typeof(PauseSetter))]
    [RequireComponent(typeof(Advertising))]
    [RequireComponent(typeof(ChooserLevelNameForLoad))]
    [RequireComponent(typeof(ScenesNames))]

    public class GameControllerRequireComponents : MonoBehaviour
    {
    }
}