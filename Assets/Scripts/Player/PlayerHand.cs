using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    private Transform _playerPosition;
    [SerializeField] private float _timeBeforeDestroy;
    private static int _damage = 5;

    public static int Damage 
    { 
        get { return _damage; } 
        set { _damage = value; }
    }

    private void Awake()
    {
        _playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        _timeBeforeDestroy = Player.AttackCD;
    }

    void Update()
    {   
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            if (Player.AttackDirection == "up")
            {
                float x = _playerPosition.position.x;
                float y = _playerPosition.position.y + 1;
                transform.position = new Vector3(x, y, 0);
            }
            else if (Player.AttackDirection == "down")
            {
                float x = _playerPosition.position.x;
                float y = _playerPosition.position.y - 1;
                transform.position = new Vector3(x, y, 0);
            }
            else if (Player.AttackDirection == "right")
            {
                float x = _playerPosition.position.x + 1;
                float y = _playerPosition.position.y;
                transform.position = new Vector3(x, y, 0);
            }
            else if (Player.AttackDirection == "left")
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

}
