using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    [Header("Enemy Stats")]
    [SerializeField] protected int _enemyHP;
    [SerializeField] protected int _enemyDamage;
    [SerializeField] protected float _enemySpeed;
    [SerializeField] protected int _enemyArmor;
    [SerializeField] protected int _enemyMagicResist;

    [Header("Other Params")]
    [SerializeField] protected float _distanceForAggression;
    [SerializeField] private float _invulnerabilityTime;
    [SerializeField] protected int _punchPower;
    [SerializeField] protected int _getPunchPower;

    private Rigidbody2D _enemyRigidbody;
    private Collider2D _enemyCollider;
    private Rigidbody2D _playerRigidbody;
    private GameObject _playerObject;
    private float _distanceToPlayer;
    private bool _isAggressive = false;
    private float _changedSpeed;

    private void Start()
    {
        _enemyRigidbody = GetComponent<Rigidbody2D>();
        _playerObject = GameObject.FindGameObjectWithTag("Player");
        _playerRigidbody = _playerObject.GetComponent<Rigidbody2D>();
        _enemyCollider = GetComponent<Collider2D>();
        _changedSpeed = _enemySpeed;
    }

    private void Update()
    {
        if (_enemyHP <= 0)
            Destroy(gameObject);

        CheckDistance();

        AttackThePlayer();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == GameObject.FindGameObjectWithTag("Player"))
        {
            int countDamage = _enemyDamage - Player.PlayerArmor;
            if (countDamage < 1)
                countDamage = 1;
            Player.PlayerHP -= countDamage;

            if (_playerObject.gameObject.transform.position.x < gameObject.transform.position.x)
                _playerRigidbody.AddForce(new Vector3(-1, 0, 0) * _punchPower);
            if (_playerObject.gameObject.transform.position.x > gameObject.transform.position.x)
                _playerRigidbody.AddForce(new Vector3(1, 0, 0) * _punchPower);
            if (_playerObject.gameObject.transform.position.y < gameObject.transform.position.y)
                _playerRigidbody.AddForce(new Vector3(0, -1, 0) * _punchPower);
            if (_playerObject.gameObject.transform.position.y > gameObject.transform.position.y)
                _playerRigidbody.AddForce(new Vector3(0, 1, 0) * _punchPower);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == GameObject.FindGameObjectWithTag("PlayerWeapon"))
        {
            int countDamage = PlayerWeapon.Damage - _enemyArmor;
            if (countDamage < 1)
                countDamage = 1;
            _enemyHP -= countDamage;

            _enemySpeed = 0;
            _enemyCollider.enabled = false;
            Invoke("ReturnCollider", _invulnerabilityTime);
            Invoke("ReturnSpeed", _invulnerabilityTime);

            if (_playerObject.gameObject.transform.position.x < gameObject.transform.position.x)
                _enemyRigidbody.AddForce(new Vector3(1, 0, 0) * _getPunchPower);
            if (_playerObject.gameObject.transform.position.x > gameObject.transform.position.x)
                _enemyRigidbody.AddForce(new Vector3(-1, 0, 0) * _getPunchPower);
            if (_playerObject.gameObject.transform.position.y < gameObject.transform.position.y)
                _enemyRigidbody.AddForce(new Vector3(0, 1, 0) * _getPunchPower);
            if (_playerObject.gameObject.transform.position.y > gameObject.transform.position.y)
                _enemyRigidbody.AddForce(new Vector3(0, -1, 0) * _getPunchPower);
            Debug.Log($"Enemy HP: {_enemyHP}");
        }

        if (collision.gameObject == GameObject.FindGameObjectWithTag("Fireball"))
        {
            int countDamage = CountTakenMagicDamage(Fireball.FireballDamage);
            _enemyHP -= countDamage;
            Destroy(collision.gameObject);
            Debug.Log($"Enemy HP: {_enemyHP}");
        }

        if (collision.gameObject == GameObject.FindGameObjectWithTag("StunWave"))
        {
            _enemySpeed = 0;
            Invoke("ReturnSpeed", StunWave.StunDuration);
        }
    }

    private void ReturnSpeed()
    {
        _enemySpeed = _changedSpeed;
    }

    private void ReturnCollider()
    {
        _enemyCollider.enabled = true;
    }

    private int CountTakenMagicDamage(int takenDamage)
    {
        int result = takenDamage - _enemyMagicResist;
        if (result <= 1)
            result = 1;
        return result;
    }

    private void CheckDistance()
    {
        if (_playerObject.gameObject != null)
            _distanceToPlayer = Vector2.Distance(_playerObject.transform.position, gameObject.transform.position);

        if (_distanceToPlayer <= _distanceForAggression)
            _isAggressive = true;
        else
            _isAggressive = false;
    }

    private void AttackThePlayer()
    {
        if (_isAggressive == true && _playerObject.gameObject != null)
        {
            if (_playerObject.transform.position.x < gameObject.transform.position.x)
            {
                gameObject.transform.Translate(new Vector2(-_enemySpeed, 0) * Time.deltaTime);
            }
            else if (_playerObject.transform.position.x > gameObject.transform.position.x)
            {
                gameObject.transform.Translate(new Vector2(_enemySpeed, 0) * Time.deltaTime);
            }
            else if (_playerObject.transform.position.y < gameObject.transform.position.y)
            {
                gameObject.transform.Translate(new Vector2(0, -_enemySpeed) * Time.deltaTime);
            }
            else if (_playerObject.transform.position.y > gameObject.transform.position.y)
            {
                gameObject.transform.Translate(new Vector2(0, _enemySpeed) * Time.deltaTime);
            }
        }
    }
}
