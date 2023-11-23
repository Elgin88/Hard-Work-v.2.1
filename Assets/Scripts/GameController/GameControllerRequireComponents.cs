using UnityEngine;
using HardWork;

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
    [RequireComponent(typeof(ScenesNames))]
    [RequireComponent(typeof(ChooserLevelNameForLoad))]

    public class GameControllerRequireComponents : MonoBehaviour
    {
    }
}