using UnityEngine;

public class Skills : MonoBehaviour
{
    [SerializeField] private byte _skillZ;
    [SerializeField] private byte _skillX;

    [SerializeField] private GameObject _fireball;
    [SerializeField] private GameObject _stunWave;

    #region SkillManaPrice

    [SerializeField] private byte _fireballManaPrice = 6;
    [SerializeField] private byte _stunWaveManaPrice = 8;
    [SerializeField] private byte _rageManaPrice = 12;
    [SerializeField] private byte _speedBoostManaPrice = 12;

    #endregion

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
            UseSkill(_skillZ);

        if (Input.GetKeyDown(KeyCode.X))
            UseSkill(_skillX);
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

    #region Skills

    private void UseFireball()
    {
        if (Player.PlayerMP >= _fireballManaPrice)
        {
            Instantiate(_fireball, transform.position, new Quaternion());
            Player.PlayerMP -= _fireballManaPrice;
        }
    }

    private void UseStunWave()
    {
        if (Player.PlayerMP >= _stunWaveManaPrice)
        {
            Instantiate(_stunWave, transform.position, new Quaternion());
            Player.PlayerMP -= _stunWaveManaPrice;
        }
        
    }

    private void UseRage()
    {
        if (Player.PlayerMP >= _rageManaPrice)
        {
            PlayerHand.Damage += 10;
            Player.PlayerMP -= _rageManaPrice;
            Invoke("ChangeDamage", 3f);
        }
    }

    private void UseSpeedBoost()
    {
        if (Player.PlayerMP >= _speedBoostManaPrice)
        {
            Player.PlayerSpeed += 2;
            Player.PlayerMP -= _speedBoostManaPrice;
            Invoke("ChangeSpeed", 5f);
        }
    }

    #endregion

    #region AuxiliaryMethods

    private void ChangeDamage()
    {
        PlayerHand.Damage -= 10;
    }

    private void ChangeSpeed()
    {
        Player.PlayerSpeed -= 2;
    }

    #endregion

}
