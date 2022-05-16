using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    private static float _playerSpeed = 3;
    private static float _attackCD = 0.8f;
    private bool _attackReady = true;
    [SerializeField] private GameObject _playerHand;
    private static int _playerHP = 20;
    private static int _playerMP = 20;

    [Header("HUD Text")]
    [SerializeField] private Text _playerHPText;
    [SerializeField] private Text _playerMPText;

    private static int _playerArmor = 0;
    private static int _playerResist = 0;
    private static string _attackDirection;
    private GameObject _respawnPoint;

    #region -- GetSet -- 

    public static int PlayerResist
    {
        get { return _playerResist; }
        set { _playerResist = value; }
    }

    public static float PlayerSpeed
    {
        get { return _playerSpeed; }
        set { _playerSpeed = value; }
    }

    public static string AttackDirection
    {
        get { return _attackDirection; }
        set { _attackDirection = value; }
    }

    public static float AttackCD
    {
        get { return _attackCD; }
        set { _attackCD = value; }
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
        _respawnPoint = GameObject.FindGameObjectWithTag("Respawn");
    }

    private void Update()
    {
        BarPrint();
        Run();
        Atack();

        if (_playerHP <= 0)
            Respawn();
    }

    private void Respawn() // govno
    {
        _playerHP = 5;
        gameObject.transform.position = _respawnPoint.transform.position;
    }

    private void BarPrint()
    {
        _playerHPText.text = $"HP: {_playerHP}"; // Отображаем ХП
        _playerMPText.text = $"MP: {_playerMP}"; // Отображаем Ману
    }

    private void Run()
    {
        float hMove = Input.GetAxis("Horizontal");
        float vMove = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(hMove, vMove, 0) * _playerSpeed * Time.deltaTime);
    }

    private void ReloadAttack()
    {
        _attackReady = true;
    }

    private void Atack()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            _attackDirection = "up";
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            _attackDirection = "down";
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            _attackDirection = "right";
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            _attackDirection = "left";
        }
        //----
        if (Input.GetKeyDown(KeyCode.Space) && _attackReady == true)
        {
            if (_attackDirection == "up")
            {
                Instantiate(_playerHand, new Vector3(transform.position.x, transform.position.y + 1, 0), new Quaternion());
                _attackReady = false;
                Invoke("ReloadAttack", _attackCD);
            }
            else if (_attackDirection == "down")
            {
                Instantiate(_playerHand, new Vector3(transform.position.x, transform.position.y - 1, 0), new Quaternion());
                _attackReady = false;
                Invoke("ReloadAttack", _attackCD);
            }
            else if (_attackDirection == "right")
            {
                Instantiate(_playerHand, new Vector3(transform.position.x + 1, transform.position.y, 0), new Quaternion(45, 45, 0, 0));
                _attackReady = false;
                Invoke("ReloadAttack", _attackCD);
            }
            else if (_attackDirection == "left")
            {
                Instantiate(_playerHand, new Vector3(transform.position.x - 1, transform.position.y, 0), new Quaternion(45, 45, 0, 0));
                _attackReady = false;
                Invoke("ReloadAttack", _attackCD);
            }
        }
    }

    
}

