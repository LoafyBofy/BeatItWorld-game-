using UnityEngine;
using UnityEngine.UI;

public class Consumables : MonoBehaviour
{
    private static int _healthPotion = 3;
    private static int _manaPotion = 3;
    private static int _gold = 100;
    private static int _enchantedIron = 20;
    private static int _magicEssence = 30;

    [Header("Texts")]
    [SerializeField] private Text _healthPotionText;
    [SerializeField] private Text _manaPotionText;

    #region GetSet
    public static int HealthPotion
    {
        get { return _healthPotion; }
        set { _healthPotion = value; }
    }

    public static int ManaPotion
    {
        get { return _manaPotion; }
        set { _manaPotion = value; }
    }

    public static int Gold
    {
        get { return _gold; }
        set { _gold = value; }
    }

    public static int EnchantedIron
    {
        get { return _enchantedIron; }
        set { _enchantedIron = value; }
    }

    public static int MagicEssence
    {
        get { return _magicEssence; }
        set { _magicEssence = value; }
    }
    #endregion

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.C))
            UseHealthPotion();

        if (Input.GetKeyDown(KeyCode.V))
            UseManaPotion();

        PrintPotion();
    }

    private void UseHealthPotion()
    {
        if (_healthPotion > 0 && Player.PlayerHP < 20)
        {
            _healthPotion--;
            Player.PlayerHP += 10;
        }
        if (Player.PlayerHP > 20)
            Player.PlayerHP = 20;
    }

    private void UseManaPotion()
    {
        if (_manaPotion > 0 && Player.PlayerMP < 20)
        {
            _manaPotion--;
            Player.PlayerMP += 10;
        }
        if (Player.PlayerMP > 20)
            Player.PlayerMP = 20;
    }

    private void PrintPotion()
    {
        _healthPotionText.text = $"Зелье здоровья (C): {_healthPotion}";
        _manaPotionText.text = $"Зелье маны (V): {_manaPotion}";
    }
}
