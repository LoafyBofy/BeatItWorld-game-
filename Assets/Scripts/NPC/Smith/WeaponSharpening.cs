using UnityEngine;
using UnityEngine.UI;

public class WeaponSharpening : MonoBehaviour
{
    [SerializeField] private GameObject[] _selectedSharpeningText;

    [SerializeField] private Text[] _buyButtonsText;

    [SerializeField] private Text _priceText;

    [Header("CurrentValuesText")]
    [SerializeField] private Text _enchantedIronAmount;
    [SerializeField] private Text _magicEssenceAmount;

    [Header("Price (lvl 1)")]
    [SerializeField] private short _upgradeIronPrice;
    [SerializeField] private short _upgradeEssencePrice;

    private static int _currentDamage = 5;
    private static float _currentCD = 1;

    private short _switch = 0;

    #region GetSet

    public static int CurrentDamage { get { return _currentDamage; } set { _currentDamage = value; } }
    public static float CurrentSpeedAttack { get { return _currentCD; } set { _currentCD = value; }}

    #endregion

    private bool[] _sharpeningIsActive =
    {
        true, // usual [0]
        false, // heavy [1]
        false // light [2]
    };

    void Update()
    {
        Switch();

        SetColor();

        SwitchControl();

        if (Input.GetKeyDown(KeyCode.Space))
            Buy();

        PrintCurrentAmount();

        if (Input.GetKeyDown(KeyCode.Escape))
            gameObject.SetActive(false);
    }

    private void Buy()
    {
        if (_switch == 0 && (Consumables.EnchantedIron >= _upgradeIronPrice) && (Consumables.MagicEssence >= _upgradeEssencePrice) && _sharpeningIsActive[0] == false)
        {
            TakeAwayResources();
            ResetMassive();
            _sharpeningIsActive[0] = true;
            SetSharpening();
        }
        if (_switch == 1 && (Consumables.EnchantedIron >= _upgradeIronPrice) && (Consumables.MagicEssence >= _upgradeEssencePrice) && _sharpeningIsActive[1] == false)
        {
            TakeAwayResources();
            ResetMassive();
            _sharpeningIsActive[1] = true;
            SetSharpening();
        }
        if (_switch == 2 && (Consumables.EnchantedIron >= _upgradeIronPrice) && (Consumables.MagicEssence >= _upgradeEssencePrice) && _sharpeningIsActive[2] == false)
        {
            TakeAwayResources();
            ResetMassive();
            _sharpeningIsActive[2] = true;
            SetSharpening();
        }
    }

    private void TakeAwayResources()
    {
        Consumables.MagicEssence -= _upgradeEssencePrice;
        Consumables.EnchantedIron -= _upgradeIronPrice;
    }

    private void ResetMassive()
    {
        for (int i = 0; i < _sharpeningIsActive.Length; i++)
        {
            _sharpeningIsActive[i] = false;
        }
    }

    private void SetSharpening()
    {
        ResetValues();
        SetSelectedSharpening();
        if (_sharpeningIsActive[1] == true) // heavy
        {
            PlayerWeapon.Damage += 2;
            Attack.AttackCD += 0.3f;
        }

        if (_sharpeningIsActive[2] == true) // light
        {
            PlayerWeapon.Damage -= 2;
            Attack.AttackCD -= 0.2f;
        }
    }

    private void SetSelectedSharpening()
    {
        for (int i = 0; i < _sharpeningIsActive.Length; i++)
        {
            if (_sharpeningIsActive[i] == true)
                _selectedSharpeningText[i].SetActive(true);
            else
                _selectedSharpeningText[i].SetActive(false);
        }
    }

    private void ResetValues()
    {
        PlayerWeapon.Damage = _currentDamage;
        Attack.AttackCD = _currentCD;
    }

    private void PrintCurrentAmount()
    {
        _enchantedIronAmount.text = $"Зачарованного железа имеется: {Consumables.EnchantedIron}";
        _magicEssenceAmount.text = $"Магической эссенции имеется: {Consumables.MagicEssence}";
        _priceText.text = $"Цена: {_upgradeIronPrice} зачарованного железа + {_upgradeEssencePrice} магической эссенции";
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
            _buyButtonsText[0].color = Color.white;
        }
        if (_switch == 1)
        {
            ChangeColor();
            _buyButtonsText[1].color = Color.white;
        }
        if (_switch == 2)
        {
            ChangeColor();
            _buyButtonsText[2].color = Color.white;
        }

    }

    private void ChangeColor()
    {
        foreach (var item in _buyButtonsText)
        {
            item.color = Color.black;
        }
    }

    private void SwitchControl()
    {
        if (_switch < 0)
            _switch = 0;
        else if (_switch > 2)
            _switch = 2;
    }
}
