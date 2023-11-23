using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HardWork
{
    public class GarageUI : MonoBehaviour
    {
        [SerializeField] private float _rangeToClosePanel;
        [SerializeField] private RequireComponentsForUI _requireComponentsForUI;

        private Coroutine _checkDistance;
        private IndicatorsEducation _indicatorsEducation;

        private void OnEnable()
        {
            if (SceneManager.GetActiveScene().name == "Level1")
            {
                _indicatorsEducation = FindObjectOfType<IndicatorsEducation>();
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