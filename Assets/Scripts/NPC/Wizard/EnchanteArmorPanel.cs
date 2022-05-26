using UnityEngine;
using UnityEngine.UI;

public class EnchanteArmorPanel : MonoBehaviour
{
    [SerializeField] private GameObject[] _selectedEnchanteText;

    [SerializeField] private Text[] _buyButtonsText;

    [SerializeField] private Text _priceText;

    [Header("CurrentValuesText")]
    [SerializeField] private Text _goldAmount;
    [SerializeField] private Text _magicEssenceAmount;

    [Header("Price (lvl 1)")]
    [SerializeField] private short _upgradeGoldPrice;
    [SerializeField] private short _upgradeEssencePrice;

    private static int _currentArmor = 0;
    private static int _currentMagicResist = 0;

    private short _switch = 0;

    #region GetSet

    public static int CurrentArmor { get { return _currentArmor; } set { _currentArmor = value; } }
    public static int CurrentMagicResist { get { return _currentMagicResist; } set { _currentMagicResist = value; } }

    #endregion

    private bool[] _enchantedIsActive =
    {
        true, // usual [0]
        false, // stone armor [1]
        false // magic armor [2]
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
        if (_switch == 0 && (Consumables.Gold >= _upgradeGoldPrice) && _enchantedIsActive[0] == false)
        {
            Consumables.Gold -= _upgradeGoldPrice;
            ResetMassive();
            _enchantedIsActive[0] = true;
            SetEnchanted();
        }
        if (_switch == 1 && (Consumables.Gold >= _upgradeGoldPrice) && (Consumables.MagicEssence >= _upgradeEssencePrice) && _enchantedIsActive[1] == false)
        {
            TakeAwayResources();
            ResetMassive();
            _enchantedIsActive[1] = true;
            SetEnchanted();
        }
        if (_switch == 2 && (Consumables.Gold >= _upgradeGoldPrice) && (Consumables.MagicEssence >= _upgradeEssencePrice) && _enchantedIsActive[2] == false)
        {
            TakeAwayResources();
            ResetMassive();
            _enchantedIsActive[2] = true;
            SetEnchanted();
        }
    }

    private void TakeAwayResources()
    {
        Consumables.MagicEssence -= _upgradeEssencePrice;
        Consumables.Gold -= _upgradeGoldPrice;
    }

    private void ResetMassive()
    {
        for (int i = 0; i < _enchantedIsActive.Length; i++)
        {
            _enchantedIsActive[i] = false;
        }
    }

    private void SetEnchanted()
    {
        ResetValues();
        SetSelectedEnchanted();
        if (_enchantedIsActive[1] == true) // stone armor
        {
            Player.PlayerArmor += 2;
            Player.MagicResist -= 2;
        }

        if (_enchantedIsActive[2] == true) // magic armor
        {
            Player.PlayerArmor -= 2;
            Player.MagicResist += 2;
        }
    }

    private void SetSelectedEnchanted()
    {
        for (int i = 0; i < _enchantedIsActive.Length; i++)
        {
            if (_enchantedIsActive[i] == true)
                _selectedEnchanteText[i].SetActive(true);
            else
                _selectedEnchanteText[i].SetActive(false);
        }
    }

    private void ResetValues()
    {
        Player.PlayerArmor = _currentArmor;
        Player.MagicResist = _currentMagicResist;
    }

    private void PrintCurrentAmount()
    {
        _goldAmount.text = $"Золото имеется: {Consumables.Gold}";
        _magicEssenceAmount.text = $"Магической эссенции имеется: {Consumables.MagicEssence}";
        _priceText.text = $"Цена: {_upgradeGoldPrice} золота + {_upgradeEssencePrice} магической эссенции";
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
