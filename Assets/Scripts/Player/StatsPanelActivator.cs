using UnityEngine;
using UnityEngine.UI;

public class StatsPanelActivator : MonoBehaviour
{
    [SerializeField] private Text _playerDamageText;
    [SerializeField] private Text _playerArmorText;
    [SerializeField] private Text _goldText;
    [SerializeField] private Text _enchantedIronText;
    [SerializeField] private Text _magicEssenceText;
    [SerializeField] private GameObject _statsPanel;
    private bool _statsPanelIsActive;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            _statsPanelIsActive = !_statsPanelIsActive;
        }

        if (_statsPanelIsActive == true)
        {
            _statsPanel.SetActive(true);
        }
        else if (_statsPanelIsActive == false)
        {
            _statsPanel.SetActive(false);
        }

        PrintPlayerStats();
    }

    private void PrintPlayerStats()
    {
        _playerDamageText.text = $"���� ����: {PlayerHand.Damage}";
        _playerArmorText.text = $"�����: {Player.PlayerArmor}";
        _goldText.text = $"������: {Consumables.Gold}";
        _enchantedIronText.text = $"������������\n ������: {Consumables.EnchantedIron}";
        _magicEssenceText.text = $"����������\n ��������: {Consumables.MagicEssence}";
    }
}
