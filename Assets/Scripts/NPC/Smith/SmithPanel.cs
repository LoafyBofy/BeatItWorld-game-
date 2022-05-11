using UnityEngine;
using UnityEngine.UI;

public class SmithPanel : MonoBehaviour
{
    [SerializeField] private Text _duringDamage;
    [SerializeField] private Text _duringArmor;
    [SerializeField] private Text _EnchantedArmorAmount;
    [SerializeField] private Image[] _buttonsColor;
    [SerializeField] private short _switch = 0;
    private short _upgradePrice = 5;

    void Update()
    {
        Switch();

        SetColor();

        SwitchControl();

        Buy();

        PrintDuringAmount();
    }

    private void Buy()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_switch == 0 && (Consumables.EnchantedIron >= _upgradePrice))
            {
                Consumables.EnchantedIron -= _upgradePrice;
                PlayerHand.Damage += 3;
            }
            else if (_switch == 1 && (Consumables.EnchantedIron >= _upgradePrice))
            {
                Consumables.EnchantedIron -= _upgradePrice;
                Player.PlayerArmor += 3;
            }
        }
    }

    private void PrintDuringAmount()
    {
        _duringDamage.text = $"Текущий урон меча: {PlayerHand.Damage}";
        _duringArmor.text = $"Текущая броня: {Player.PlayerArmor}";
        _EnchantedArmorAmount.text = $"Зачарованного железа имеется: {Consumables.EnchantedIron}";
    }

    private void Switch()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _switch--;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _switch++;
        }
    }

    private void SetColor()
    {
        if (_switch == 0)
        {
            _buttonsColor[0].color = Color.red;
            _buttonsColor[1].color = Color.white;
        }
        else if (_switch == 1)
        {
            _buttonsColor[0].color = Color.white;
            _buttonsColor[1].color = Color.red;
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
