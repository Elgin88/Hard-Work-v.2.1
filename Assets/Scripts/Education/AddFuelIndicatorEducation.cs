using UnityEngine;
using UnityEngine.SceneManagement;

public class AddFuelIndicatorEducation : MonoBehaviour
{
    [SerializeField] private GarageIndicatorEducation[] _garageIndicatorEducation;

    private string _level1Name = "Level1";

    private void Start()
    {
        if (SceneManager.GetActiveScene().name != _level1Name)
        {
            Destroy(gameObject);
        }

        foreach (var indicator in _garageIndicatorEducation)
        {
            if (indicator != null)
            {
                Destroy(indicator.gameObject);
            }            
        }
    }
}