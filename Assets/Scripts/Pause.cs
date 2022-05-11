using UnityEngine;

public class Pause : MonoBehaviour
{
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
            }
            else 
            {
                Time.timeScale = 1;
            }
        }
    }
    

    
    
}
