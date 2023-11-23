using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AddFuelIndicatorEducation : MonoBehaviour
{
    [SerializeField] private GarageIndicatorEducation[] _garageIndicatorEducation;
    [SerializeField] private JoystickIndicatorEducation[] _joystickIndicatorEducation;
    [SerializeField] private Button _button;

    private string _level1Name = "Level1";

    private void OnEnable()
    {
        if (SceneManager.GetActiveScene().name != _level1Name)
        {
            Destroy(gameObject);
        }

        foreach (var indicator in _garageIndicatorEducation)
        {
            if (indicator != null)
            {
                if (indicator != null)
                {
                    Destroy(indicator.gameObject);
                }
            }
        }

        if (_button != null)
        {
            _button.onClick.AddListener(OnButtonClick);
        }
    }

    private void OnDisable()
    {
        if (_button != null)
        {
            _button.onClick.RemoveListener(OnButtonClick);
        }
    }

    private void OnButtonClick()
    {
        foreach (var item in _joystickIndicatorEducation)
        {
            if (item != null)
            {
                item.gameObject.SetActive(true);
            }
        }
    }
}