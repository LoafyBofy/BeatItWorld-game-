using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    [SerializeField] protected int _enemyHP;
    [SerializeField] protected int _enemyDamage;
    [SerializeField] protected int _enemyArmor;
    [SerializeField] protected int _enemyMagicResist;
    [SerializeField] protected float _distanceForAggression;
    [SerializeField] protected float _enemySpeed;

    private Rigidbody2D _enemyRigidbody;
    private GameObject _playerObject;
    private float _distanceToPlayer;
    private bool _isAggressive = false;
    private float _changedSpeed;

    private void Start()
    {
        _enemyRigidbody = GetComponent<Rigidbody2D>();
        _playerObject = GameObject.FindGameObjectWithTag("Player");
        _changedSpeed = _enemySpeed;
    }

    private void Update()
    {
        if (_enemyHP <= 0)
            Destroy(gameObject);

        CheckDistance();

        AttackThePlayer();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == GameObject.FindGameObjectWithTag("Player"))
        {
            int countDamage = _enemyDamage - Player.PlayerArmor;
            if (countDamage < 1)
                countDamage = 1;
            Player.PlayerHP -= countDamage;
        }

        if (collision.gameObject == GameObject.FindGameObjectWithTag("PlayerWeapon"))
        {
            _enemyHP -= PlayerHand.Damage;
            _enemyRigidbody.AddForce(new Vector3(0, 1, 0) * 200f);
            Debug.Log($"Enemy HP: {_enemyHP}");
        }

        if (collision.gameObject == GameObject.FindGameObjectWithTag("Fireball"))
        {
            int countDamage = CountTakenMagicDamage(Fireball.FireballDamage);
            _enemyHP -= countDamage;
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
