using UnityEngine;
using UnityEngine.UI;

public class ShopActivator : MonoBehaviour
{
    [SerializeField] private Text _interactionText;
    [SerializeField] private GameObject _interactionTextObject;
    [SerializeField] private GameObject _shopPanel;
    private bool _inArea;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _inArea == true)
        {
            _shopPanel.SetActive(!_shopPanel.activeSelf);
            if (_shopPanel.activeSelf)
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
            _shopPanel.SetActive(false);
            Pause.Instance.IsPause = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        _interactionTextObject.SetActive(true);
        _interactionText.text = $"<b>Торговец\n Нажмите 'E' для взаимодействия</b>";
        _inArea = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _interactionTextObject.SetActive(false);
        _inArea = false;
    }
}
