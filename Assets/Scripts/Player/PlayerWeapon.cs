using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    private Transform _playerPosition;
    [SerializeField] private float _timeBeforeDestroy;
    private static int _damage = 5;
    private Collider2D _collider;

    #region GetSet

    public static int Damage 
    { 
        get { return _damage; } 
        set { _damage = value; }
    }

    #endregion

    private void Awake()
    {
        _playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        _timeBeforeDestroy = Attack.AttackCD;
        _collider = gameObject.GetComponent<Collider2D>();
    }

    void Update()
    {   
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            if (Attack.AttackDirection == "up")
            {
                float x = _playerPosition.position.x;
                float y = _playerPosition.position.y + 1;
                transform.position = new Vector3(x, y, 0);
            }
            else if (Attack.AttackDirection == "down")
            {
                float x = _playerPosition.position.x;
                float y = _playerPosition.position.y - 1;
                transform.position = new Vector3(x, y, 0);
            }
            else if (Attack.AttackDirection == "right")
            {
                float x = _playerPosition.position.x + 1;
                float y = _playerPosition.position.y;
                transform.position = new Vector3(x, y, 0);
            }
            else if (Attack.AttackDirection == "left")
            {
                float x = _playerPosition.position.x - 1;
                float y = _playerPosition.position.y;
                transform.position = new Vector3(x, y, 0);
            }
        }

        _timeBeforeDestroy -= Time.deltaTime;
        if (_timeBeforeDestroy < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            _collider.enabled = false;
        }
    }
}
