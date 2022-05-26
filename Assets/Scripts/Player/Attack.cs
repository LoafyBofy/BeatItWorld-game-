using UnityEngine;

public class Attack : MonoBehaviour
{
    private static float _attackCD = 1;
    private bool _attackIsReady = true;
    [SerializeField] private GameObject _playerWeapon;
    private static string _attackDirection;

    #region GetSet

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

    #endregion

    private void Update()
    {
        WeaponAtack();
    }

    private void WeaponAtack()
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
        if (Input.GetKeyDown(KeyCode.Space) && _attackIsReady == true)
        {
            if (_attackDirection == "up")
            {
                Instantiate(_playerWeapon, new Vector3(transform.position.x, transform.position.y + 1, 0), new Quaternion());
                _attackIsReady = false;
                Invoke("ReloadAttack", _attackCD);
            }
            else if (_attackDirection == "down")
            {
                Instantiate(_playerWeapon, new Vector3(transform.position.x, transform.position.y - 1, 0), new Quaternion());
                _attackIsReady = false;
                Invoke("ReloadAttack", _attackCD);
            }
            else if (_attackDirection == "right")
            {
                Instantiate(_playerWeapon, new Vector3(transform.position.x + 1, transform.position.y, 0), new Quaternion(45, 45, 0, 0));
                _attackIsReady = false;
                Invoke("ReloadAttack", _attackCD);
            }
            else if (_attackDirection == "left")
            {
                Instantiate(_playerWeapon, new Vector3(transform.position.x - 1, transform.position.y, 0), new Quaternion(45, 45, 0, 0));
                _attackIsReady = false;
                Invoke("ReloadAttack", _attackCD);
            }
        }
    }

    private void ReloadAttack()
    {
        _attackIsReady = true;
    }

    
}
