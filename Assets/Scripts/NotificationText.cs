using UnityEngine;
using UnityEngine.UI;

public class NotificationText : MonoBehaviour
{
    [SerializeField] private GameObject _notificationObject;
    private Text _notificationText;
    [SerializeField] private string _objectName;

    private void Start()
    {
        _notificationText = _notificationObject.GetComponentInChildren<Text>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Artifact")
        {
            _objectName = collision.gameObject.name;
        }
    }

    private void FixedUpdate()
    {
        if (Artifacts.TakenArtifact == true)
        {
            _notificationObject.SetActive(true);
            _notificationText.text = $"Подобран предмет\n '{_objectName}'";
            Invoke("PanelDeactivate", 5.0f);
        }
    }

    private void PanelDeactivate()
    {
        _notificationObject.SetActive(false);
    }
}
