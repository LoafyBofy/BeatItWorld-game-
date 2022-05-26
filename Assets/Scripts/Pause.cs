using UnityEngine;

public class Pause : MonoBehaviour
{
    GameObject PlayerObject;
    [SerializeField] bool _isPause;
    private static Pause instance;
    public static Pause Instance
    {
        get 
        { 
            if(instance == null)
                instance = Camera.main.GetComponent<Pause>();
            return instance; 
        }
    }

    private void Start()
    {
        PlayerObject = GameObject.FindGameObjectWithTag("Player");
    }

    public bool IsPause
    {
        get 
        { 
            return _isPause; 
        }
        set 
        { 
            _isPause = value; 
            if (_isPause)
            {
                Time.timeScale = 0;
                PlayerObject.gameObject.GetComponent<Attack>().enabled = false;
                PlayerObject.gameObject.GetComponent<Skills>().enabled = false;
                PlayerObject.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
            else 
            {
                Time.timeScale = 1;
                PlayerObject.gameObject.GetComponent<Attack>().enabled = true;
                PlayerObject.gameObject.GetComponent<Skills>().enabled = true;
                PlayerObject.gameObject.GetComponent<BoxCollider2D>().enabled = true;
            }
        }
    }
    

    
    
}
