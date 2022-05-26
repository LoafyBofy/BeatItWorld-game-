using UnityEngine;

public class TeleportA : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _TeleportB;
    [SerializeField] private bool _inArea = false;
    private float x;
    private float y;
    private GameObject _camera;

    private void Start()
    {
        x = _TeleportB.transform.position.x;
        y = _TeleportB.transform.position.y;
        _camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.E) && _inArea == true)
        {
            _player.transform.position = new Vector3(x, y, 0);
            _camera.transform.position = new Vector3(x, y, 0);
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
