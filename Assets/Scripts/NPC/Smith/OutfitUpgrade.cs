using UnityEngine;
using UnityEngine.UI;

public class OutfitUpgrade : MonoBehaviour
{
    [Header("Texts")]
    [SerializeField] private Text _currentDamage;
    [SerializeField] private Text _currentArmor;
    [SerializeField] private Text _EnchantedIronAmount;
    [SerializeField] private Text[] _buttonsColor;

    [Header("Price")]
    [SerializeField] private short _upgradePrice = 5;

    [Header("Restrictions")]
    [SerializeField] private byte _swordUpgradeLimit = 0;
    [SerializeField] private byte _armorUpgradeLimit = 0;

    private short _switch = 0;

    void Update()
    {
        Switch();

        SetColor();

        SwitchControl();

        ChangeText();

        Buy();

        PrintCurrentAmount();

        if (Input.GetKeyDown(KeyCode.Escape))
            gameObject.SetActive(false);
    }

    private void Buy()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_switch == 0 && (Consumables.EnchantedIron >= _upgradePrice) && _swordUpgradeLimit < 3) // sword upgrade
            {
                Consumables.EnchantedIron -= _upgradePrice;
                PlayerWeapon.Damage += 3;
                WeaponSharpening.CurrentDamage += 3;
                _swordUpgradeLimit++;
            }
            else if (_switch == 1 && (Consumables.EnchantedIron >= _upgradePrice) && _armorUpgradeLimit < 3) // armor upgrade
            {
                Consumables.EnchantedIron -= _upgradePrice;
                Player.PlayerArmor += 3;
                EnchanteArmorPanel.CurrentArmor += 3;
                _armorUpgradeLimit++;
            }
        }
    }

    private void ChangeText()
    {
        if (_swordUpgradeLimit == 3)
            _buttonsColor[0].text = "Максимальное\n улучшение";
        if (_armorUpgradeLimit == 3)
            _buttonsColor[1].text = "Максимальное\n улучшение";
    }

    private void PrintCurrentAmount()
    {
        _currentDamage.text = $"Текущий урон меча: {PlayerWeapon.Damage}";
        _currentArmor.text = $"Текущая броня: {Player.PlayerArmor}";
        _EnchantedIronAmount.text = $"Зачарованного железа имеется: {Consumables.EnchantedIron}";
    }

    private void Switch()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            _switch--;
        if (Input.GetKeyDown(KeyCode.RightArrow))
            _switch++;
    }

    private void SetColor()
    {
        if (_switch == 0)
        {
            ChangeColor();
            _buttonsColor[0].color = Color.white;
        }
        if (_switch == 1)
        {
            ChangeColor();
            _buttonsColor[1].color = Color.white;
        }
    }

    private void ChangeColor()
    {
        foreach (var item in _buttonsColor)
        {
            item.color = Color.black;
        }
    }

    private void SwitchControl()
    {
        if (_switch < 0)
            _switch = 0;
        else if (_switch > 1)
            _switch = 1;
    }
}
