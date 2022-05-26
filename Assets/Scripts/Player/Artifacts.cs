using UnityEngine;

public class Artifacts : MonoBehaviour
{
    [SerializeField] private bool _inArea = false;
    [SerializeField] private string _artifactName;

    private static bool _takenArtifact = false;
    private static byte _artifactsAmount = 0;
    
    #region GetSet

    public static bool TakenArtifact { get { return _takenArtifact; } }

    public static byte ArtifactsAmount { get { return _artifactsAmount; } set { _artifactsAmount = value; } }

    #endregion

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.E) && _inArea == true)
        {
            TakeArtifact();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Artifact")
        {
            _inArea = true;
            _artifactName = collision.gameObject.name;
        }
        

        if (_takenArtifact == true)
        {
            Destroy(collision.gameObject);
            _takenArtifact = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _inArea = false;
    }

    private void TakeArtifact() // При добавлении урони и скорости атаки менять занчения в WeaponSharpening и EnchanteArmorPanel
    {
        if (_artifactName == "Перчатка силы")
        {
            _takenArtifact = true;
            PlayerWeapon.Damage += 2;
            WeaponSharpening.CurrentDamage += 2;
            ArtifactPlus();
        }
        if (_artifactName == "Сковорода")
        {
            _takenArtifact = true;
            Player.PlayerArmor += 1;
            EnchanteArmorPanel.CurrentArmor += 1;
            PlayerWeapon.Damage += 1;
            WeaponSharpening.CurrentDamage += 1;
            ArtifactPlus();
        }
    }

    private void ArtifactPlus()
    {
        LevelController1.TakenArtifactsOnLevel++;
        ArtifactsAmount++;
    }
}
