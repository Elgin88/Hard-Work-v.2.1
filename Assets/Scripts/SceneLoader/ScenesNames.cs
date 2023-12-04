using UnityEngine;

namespace HardWork.SceneLoader
{
    public class ScenesNames : MonoBehaviour
    {
        private static string _levelSDK = "LevelSDK";
        private static string _level0Name = "Level0";
        private static string _level1Name = "Level1";
        private static string _level2Name = "Level2";
        private static string _level3Name = "Level3";

        public static string LevelSDK => _levelSDK;

        public static string Level0Name => _level0Name;

        public static string Level1Name => _level1Name;

        public static string Level2Name => _level2Name;

        public static string Level3Name => _level3Name;
    }
}