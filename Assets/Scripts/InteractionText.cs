using UnityEngine;
using UnityEngine.UI;

public class InteractionText : MonoBehaviour
{
    [SerializeField] private GameObject _textObject;
    private Text _text;
    private string _objectName;

    private void Start()
    {
        _text = _textObject.GetComponent<Text>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag != "Artifact")
        {
            _textObject.SetActive(true);
            _objectName = collision.gameObject.name;
            _text.text = $"{_objectName}\nНажмите 'E' для взаимодействия";
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _textObject.SetActive(false);
    }
}
