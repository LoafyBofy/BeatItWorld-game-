using UnityEngine;

public class ShopActivator : MonoBehaviour
{
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
        _inArea = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _inArea = false;
    }
}
