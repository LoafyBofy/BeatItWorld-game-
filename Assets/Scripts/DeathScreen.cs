using UnityEngine;
using UnityEngine.UI;

public class DeathScreen : MonoBehaviour
{
    [SerializeField] private GameObject _playerObject;
    [SerializeField] private GameObject _deathScreenObject;
    [SerializeField] private Text _timeBeforeRebornText;
    private Collider2D _playerCollider;
    private GameObject _respawnPoint;
    private GameObject _mainCamera;

    private float _timeBeforeRborn = 3;

    private void Start()
    {
        _playerCollider = _playerObject.GetComponent<Collider2D>();
        _respawnPoint = GameObject.FindGameObjectWithTag("Respawn");
        _mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    private void Update()
    {
        if (Player.PlayerHP < 1)
        {
            _playerObject.SetActive(false);
            _deathScreenObject.SetActive(true);
            _timeBeforeRborn -= Time.deltaTime;
            _timeBeforeRebornText.text = $"Возрождение у алтаря через: {Mathf.Round(_timeBeforeRborn)}";
            if (_timeBeforeRborn <= 0)
                Respawn();
        }
    }

    private void Respawn()
    {
        _playerObject.transform.position = _respawnPoint.transform.position;
        _mainCamera.transform.position = _respawnPoint.transform.position;
        Player.PlayerHP = 5;
        _playerObject.SetActive(true);
        _deathScreenObject.SetActive(false);
        _playerCollider.enabled = false;
        _timeBeforeRborn = 3;
        Invoke("ReturnCollider", 2f);
    }

    private void ReturnCollider()
    {
        _playerCollider.enabled = true;
    }
}
