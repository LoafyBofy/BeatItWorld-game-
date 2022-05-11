using UnityEngine;
using UnityEngine.UI;

public class ShopPanel : MonoBehaviour
{
    [SerializeField] private Text _duringHPPotionAmount;
    [SerializeField] private Text _duringMPPotionAmount;
    [SerializeField] private Text _GoldAmount;
    [SerializeField] private Image[] _buttonsColor;
    [SerializeField] private short _switch = 0;
    private short _potionHPandMPPrice = 20;

    void Update()
    {
        Switch();

        SetColor();

        SwitchControl();

        Buy();

        PrintDuringAmount();
    }

    private void PrintDuringAmount()
    {
        _duringHPPotionAmount.text = $"Текущее количество {Consumables.HealthPotion}";
        _duringMPPotionAmount.text = $"Текущее количество {Consumables.ManaPotion}";
        _GoldAmount.text = $"Золота имеется: {Consumables.Gold}";
    }

    private void Buy()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_switch == 0 && (Consumables.Gold >= _potionHPandMPPrice))
            {
                Consumables.Gold -= _potionHPandMPPrice;
                Consumables.HealthPotion++;
            }
            else if (_switch == 1 && (Consumables.Gold >= _potionHPandMPPrice))
            {
                Consumables.Gold -= _potionHPandMPPrice;
                Consumables.ManaPotion++;
            }
        }
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
