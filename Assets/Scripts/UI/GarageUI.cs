using System.Collections;
using HardWork.Education;
using HardWork.SceneLoader;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HardWork.UI
{
    public class GarageUI : MonoBehaviour
    {
        [SerializeField] private float _rangeToClosePanel;
        [SerializeField] private RequireComponentsForUI _requireComponentsForUI;
        [SerializeField] private IndicatorsEducation _indicatorsEducation;

        private Coroutine _checkDistance;

        private void OnEnable()
        {
            if (SceneManager.GetActiveScene().name == ScenesNames.Level1Name)
            {
                _indicatorsEducation.GarageIndicatorsEducationDisable();
            }

            StartCheckDistance();
        }

        private void OnDisable()
        {
            StopCheckDistance();
        }

        private IEnumerator CheckDistance()
        {
            while (true)
            {
                if (Vector3.Distance(_requireComponentsForUI.DestroyerPoint.transform.position, _requireComponentsForUI.GarageParkingArea.transform.position) > _rangeToClosePanel)
                {
                    gameObject.SetActive(false);
                }

                yield return null;
            }
        }

        private void StartCheckDistance()
        {
            if (_checkDistance == null)
            {
                _checkDistance = StartCoroutine(CheckDistance());
            }
        }

        private void StopCheckDistance()
        {
            if (_checkDistance != null)
            {
                StopCoroutine(_checkDistance);
                _checkDistance = null;
            }
        }
    }
}