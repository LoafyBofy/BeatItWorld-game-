using UnityEngine;
using UnityEngine.UI;

public class WizardActivator : MonoBehaviour
{
    [SerializeField] private Text _interactionText;
    [SerializeField] private GameObject _interactionTextObject;
    [SerializeField] private GameObject _wizardPanel;
    private bool _inArea;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _inArea == true)
        {
            _wizardPanel.SetActive(!_wizardPanel.activeSelf);
            if (_wizardPanel.activeSelf)
            {
                Pause.Instance.IsPause = true;
            }
            else
            {
                Pause.Instance.IsPause = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            _wizardPanel.SetActive(false);
            Pause.Instance.IsPause = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        _interactionTextObject.SetActive(true);
        _interactionText.text = $"<b>Волшебник\n Нажмите 'E' для взаимодействия</b>";
        _inArea = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _interactionTextObject.SetActive(false);
        _inArea = false;
    }
}
