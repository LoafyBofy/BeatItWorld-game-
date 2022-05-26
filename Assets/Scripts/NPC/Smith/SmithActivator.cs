using UnityEngine;

public class SmithActivator : MonoBehaviour
{
    [SerializeField] private GameObject _smithPanel;
    private bool _inArea;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _inArea == true)
        {
            _smithPanel.SetActive(!_smithPanel.activeSelf);
            if (_smithPanel.activeSelf)
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
            _smithPanel.SetActive(false);
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