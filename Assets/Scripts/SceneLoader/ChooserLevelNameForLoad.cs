using UnityEngine;
using UnityEngine.SceneManagement;

namespace HardWork
{
    public class ChooserLevelNameForLoad : MonoBehaviour
    {
        [SerializeField] private Loader _loader;

        private string _currentSceneName;
        private string _nextSceneName;
        private string _savedSceneName;

        private void Start()
        {
            _currentSceneName = SceneManager.GetActiveScene().name;
        }

        public string GetNextSceneName()
        {
            if (_currentSceneName == ScenesNames.LevelSDK)
            {
                _nextSceneName = ScenesNames.Level0Name;
            }
            else if (_currentSceneName == ScenesNames.Level0Name)
            {
                _nextSceneName = ScenesNames.Level1Name;
            }
            else if (_currentSceneName == ScenesNames.Level1Name)
            {
                _nextSceneName = ScenesNames.Level2Name;
            }
            else if (_currentSceneName == ScenesNames.Level2Name)
            {
                _nextSceneName = ScenesNames.Level3Name;
            }
            else if (_currentSceneName == ScenesNames.Level3Name)
            {
                _nextSceneName = ScenesNames.Level1Name;
            }

            if (_currentSceneName == ScenesNames.Level0Name & _loader.GetSceneNameForLoad() != string.Empty)
            {
                _nextSceneName = _loader.GetSceneNameForLoad();
            }

            return _nextSceneName;
        }
    }
}