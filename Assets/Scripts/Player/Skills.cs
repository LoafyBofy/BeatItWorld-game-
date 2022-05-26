using UnityEngine;
using UnityEngine.UI;

public class Skills : MonoBehaviour
{
    private static byte _skillZ = 0;
    private static byte _skillX = 0;

    [Header("Prefabs")]
    [SerializeField] private GameObject _fireball;
    [SerializeField] private GameObject _stunWave;

    [Header("Texts")]
    [SerializeField] private Text SkillZText;
    [SerializeField] private Text SkillXText;

    [Header("SkillsManaPrice")]
    [SerializeField] private byte _fireballManaPrice = 6;
    [SerializeField] private byte _stunWaveManaPrice = 8;
    [SerializeField] private byte _rageManaPrice = 12;
    [SerializeField] private byte _accelerationManaPrice = 12;

    [Header("SkillsCD")]
    [SerializeField] private float _fireballCD;
    [SerializeField] private float _stunWaveCD;
    [SerializeField] private float _rageCD;
    [SerializeField] private float _accelerationCD;

    #region GetSet

    public static byte SkillZ
    {
        get { return _skillZ; }
        set { _skillZ = value; }
    }

    public static byte SkillX
    {
        get { return _skillX; }
        set { _skillX = value; }
    }

    #endregion

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
            UseSkill(_skillZ);

        if (Input.GetKeyDown(KeyCode.X))
            UseSkill(_skillX);

        SetSkillsText();
    }

    private void SetSkillsText()
    {
        switch (_skillZ)
        {
            case 1:
                SkillZText.text = "Огненный шар";
                break;
            case 2:
                SkillZText.text = "Оглушающая волна";
                break;
            case 3:
                SkillZText.text = "Ярость";
                break;
            case 4:
                SkillZText.text = "Ускорение";
                break;
        }

        switch (_skillX)
        {
            case 1:
                SkillXText.text = "Огненный шар";
                break;
            case 2:
                SkillXText.text = "Оглушающая волна";
                break;
            case 3:
                SkillXText.text = "Ярость";
                break;
            case 4:
                SkillXText.text = "Ускорение";
                break;
        }
    }

    private void UseSkill(byte skillNumber)
    {
        switch (skillNumber)
        {
            case 1:
                UseFireball();
                break;
            case 2:
                UseStunWave();
                break;
            case 3:
                UseRage();
                break;
            case 4:
                UseSpeedBoost();
                break;
        }
    }

    #region SkillsIsReady

    private bool _fireballIsReady = true;
    private bool _stunWaveIsReady = true;
    private bool _rageIsReady = true;
    private bool _accelerationIsReady = true;

    #endregion

    #region SkillsMethods

    private void UseFireball()
    {
        if (Player.PlayerMP >= _fireballManaPrice && _fireballIsReady == true)
        {
            Instantiate(_fireball, transform.position, new Quaternion());
            Player.PlayerMP -= _fireballManaPrice;
            _fireballIsReady = false;
            Invoke("FireballReload", _fireballCD);
        }
    }

    private void UseStunWave()
    {
        if (Player.PlayerMP >= _stunWaveManaPrice && _stunWaveIsReady == true)
        {
            Instantiate(_stunWave, transform.position, new Quaternion());
            Player.PlayerMP -= _stunWaveManaPrice;
            _stunWaveIsReady = false;
            Invoke("StunWaveReload", _stunWaveCD);
        }
    }

    private void UseRage()
    {
        if (Player.PlayerMP >= _rageManaPrice && _rageIsReady == true)
        {
            PlayerWeapon.Damage += 10;
            Player.PlayerMP -= _rageManaPrice;
            _rageIsReady = false;
            Invoke("ChangeDamage", 3.5f);
        }
    }

    private void UseSpeedBoost()
    {
        if (Player.PlayerMP >= _accelerationManaPrice && _accelerationIsReady == true)
        {
            PlayerMove.PlayerSpeed += 2;
            Player.PlayerMP -= _accelerationManaPrice;
            _accelerationIsReady = false;
            Invoke("ChangeSpeed", 1.5f);
        }
    }

    #endregion

    #region AuxiliaryMethods

    private void FireballReload()
    {
        _fireballIsReady = true;
    }

    private void StunWaveReload()
    {
        _stunWaveIsReady = true;
    }

    private void RageReload()
    {
        _rageIsReady = true;
    }

    private void AccelerationReload()
    {
        _accelerationIsReady = true;
    }

    private void ChangeDamage()
    {
        PlayerWeapon.Damage -= 10;
        Invoke("RageReload", _rageCD);
    }

    private void ChangeSpeed()
    {
        PlayerMove.PlayerSpeed -= 2;
        Invoke("AccelerationReload", _accelerationCD);
    }

    #endregion

}
