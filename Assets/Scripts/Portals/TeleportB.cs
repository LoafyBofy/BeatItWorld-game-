using UnityEngine;
using UnityEngine.UI;

public class TeleportB : MonoBehaviour
{
    [SerializeField] private Text _interactionText;
    [SerializeField] private GameObject _interactionTextObject;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _TeleportA;
    [SerializeField] private bool _inArea = false;
    private float x;
    private float y;

    private void Start()
    {
        x = _TeleportA.transform.position.x;
        y = _TeleportA.transform.position.y;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.E) && _inArea == true)
        {
            _player.transform.position = new Vector3(x, y, 0);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        _interactionTextObject.SetActive(true);
        _interactionText.text = $"<b>������\n ������� 'E' ��� ��������������</b>";
        _inArea = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _interactionTextObject.SetActive(false);
        _inArea = false;
    }
}