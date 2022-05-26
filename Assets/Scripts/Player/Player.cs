using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private static int _playerHP = 20;
    private static int _playerMP = 20;

    [SerializeField] private float _invulnerabilityTime;

    [Header("HUD Text")]
    [SerializeField] private Text _playerHPText;
    [SerializeField] private Text _playerMPText;

    private static int _playerArmor = 0;
    private static int _playerMagicResist = 0;

    private Collider2D _collider;

    #region -- GetSet -- 

    public static int MagicResist
    {
        get { return _playerMagicResist; }
        set { _playerMagicResist = value; }
    }

    public static int PlayerArmor
    {
        get { return _playerArmor; }
        set { _playerArmor = value; }
    }

    public static int PlayerHP
    {
        get { return _playerHP; }
        set { _playerHP = value; }
    }

    public static int PlayerMP
    {
        get { return _playerMP; }
        set { _playerMP = value; }
    }
    #endregion

    private void Start()
    {
        _collider = gameObject.GetComponent<Collider2D>();
    }

    private void Update()
    {
        PrintBar();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            _collider.enabled = false;
            gameObject.GetComponent<PlayerMove>().enabled = false;
            Invoke("SetColiderTrue", _invulnerabilityTime);
            Invoke("SetComponentPlayerMoveTrue", _invulnerabilityTime);
        }
    }

    private void PrintBar()
    {
        _playerHPText.text = $"HP: {_playerHP}"; // Отображаем ХП
        _playerMPText.text = $"MP: {_playerMP}"; // Отображаем Ману
    }

    private void SetColiderTrue()
    {
        _collider.enabled = true;
    }

    private void SetComponentPlayerMoveTrue()
    {
        gameObject.GetComponent<PlayerMove>().enabled = true;
    }
}

