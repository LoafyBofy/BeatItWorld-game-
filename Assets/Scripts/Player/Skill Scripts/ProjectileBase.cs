using UnityEngine;

public abstract class ProjectileBase : MonoBehaviour
{
    [SerializeField] private float _timeBeforeDestroy;
    [SerializeField] private float _projectileSpeed;
    private string _projectileDirection;

    private void Start()
    {
        _projectileDirection = Player.AttackDirection;

        if (_projectileDirection == "right" || _projectileDirection == "left")
        {
           gameObject.transform.Rotate(new Vector3(0, 0, 90));
        }
    }

    private void Update()
    {
        _timeBeforeDestroy -= Time.deltaTime;

        CheckTimeBeforeDestroy();

        ProjectileMove();
    }

    private void CheckTimeBeforeDestroy()
    {
        if (_timeBeforeDestroy < 0)
            Destroy(gameObject);
    }

    private void ProjectileMove()
    {
        if (_projectileDirection == "up")
        {
            transform.Translate(new Vector3(0, 1, 0) * _projectileSpeed * Time.deltaTime);
        }
        else if (_projectileDirection == "down")
        {
            transform.Translate(new Vector3(0, -1, 0) * _projectileSpeed * Time.deltaTime);
        }
        else if (_projectileDirection == "right")
        {
            transform.Translate(new Vector3(0, -1, 0) * _projectileSpeed * Time.deltaTime);
        }
        else if (_projectileDirection == "left")
        {
            transform.Translate(new Vector3(0, 1, 0) * _projectileSpeed * Time.deltaTime);
        }
    }
}
