using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController1 : MonoBehaviour
{
    private bool _doorIsOpen = false;

    private static byte _deadOgresAmount;
    private static byte _deadScorponsAmount;
    private static byte _takenTreasureAmount;

    private GameObject[] _allArtifactsArray;
    private static byte _allArtifactsOnLevel;
    private static byte _takenArtifactsOnLevel = 0;

    #region GetSet

    public static byte DeadOgresAmount { get { return _deadOgresAmount; } set { _deadOgresAmount = value; } }

    public static byte DeadScorpionsAmount { get { return _deadScorponsAmount; } set { _deadScorponsAmount = value; } }

    public static byte TakenTreasureAmount { get { return _takenTreasureAmount; } set { _takenTreasureAmount = value; } }

    public static byte TakenArtifactsOnLevel { get { return _takenArtifactsOnLevel; } set { _takenArtifactsOnLevel = value; } }

    public static byte AllArtifactsOnLevel { get { return _allArtifactsOnLevel; } set { _allArtifactsOnLevel = value; } }

    #endregion

    [Header("Requirements")]
    [SerializeField] private int _deadOgres;
    [SerializeField] private int _deadScorpons;
    [SerializeField] private int _treasureAmount;

    private void Start()
    {
        _allArtifactsArray = GameObject.FindGameObjectsWithTag("Artifact");
        _allArtifactsOnLevel = (byte)_allArtifactsArray.Length;
    }

    private void Update()
    {
        if (_deadOgresAmount == _deadOgres && _deadScorponsAmount == _deadScorpons && _takenTreasureAmount == _treasureAmount)
            _doorIsOpen = true;

        
    }
}
