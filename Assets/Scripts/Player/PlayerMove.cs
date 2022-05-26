using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private static float _playerSpeed = 3;

    public static float PlayerSpeed
    {
        get { return _playerSpeed; }
        set { _playerSpeed = value; }
    }

    private void Update()
    {
        float hMove = Input.GetAxis("Horizontal");
        float vMove = Input.GetAxis("Vertical");
        transform.Translate(new Vector2(hMove, vMove) * _playerSpeed * Time.deltaTime);
    }

   
}
