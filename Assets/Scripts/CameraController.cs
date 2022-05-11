using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _playerPosition;
    [SerializeField] private float step = 1;

    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            float x = _playerPosition.position.x;
            float y = _playerPosition.position.y;

            transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3(x, y, -15), step * Time.deltaTime);
        }
        
    }
}
