using UnityEngine;

public class WizardActivator : MonoBehaviour
{
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
        _inArea = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _inArea = false;
    }
}
