using UnityEngine;
using UnityEngine.UI;

public class ChoicePanel : MonoBehaviour
{
    [Header("Texts")]
    [SerializeField] private Text _firstPanelText;
    [SerializeField] private Text _secondPanelText;

    [Header("Game Objects")]
    [SerializeField] private GameObject _firstPanelObject;
    [SerializeField] private GameObject _secondPanelObject;

    private byte _currentItem = 1;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.DownArrow))
            _currentItem++;
        if (Input.GetKeyUp(KeyCode.UpArrow))
            _currentItem--;

        SetColor();
        CheckItem();
        AcitvePanel();
    }

    private void SetColor()
    {
        switch (_currentItem)
        {
            case 1:
                _firstPanelText.color = Color.white;
                _secondPanelText.color = Color.black;
                break;
            case 2:
                _firstPanelText.color = Color.black;
                _secondPanelText.color = Color.white;
                break;
        }
    }

    private void CheckItem()
    {
        if (_currentItem < 1)
            _currentItem = 1;
        if (_currentItem > 2)
            _currentItem = 2;
    }

    private void AcitvePanel()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _currentItem == 1)
        {
            _firstPanelObject.SetActive(true);
            gameObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && _currentItem == 2)
        {
            _secondPanelObject.SetActive(true);
            gameObject.SetActive(false);
        }

    }
}
