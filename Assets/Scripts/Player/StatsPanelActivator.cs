using UnityEngine;
using UnityEngine.UI;

public class StatsPanelActivator : MonoBehaviour
{
    [Header("Texts")]
    [SerializeField] private Text _playerWeaponDamageText;
    [SerializeField] private Text _playerAttackCdText;
    [SerializeField] private Text _moveSpeedText;
    [SerializeField] private Text _playerArmorText;
    [SerializeField] private Text _magicResistText;
    [SerializeField] private Text _goldText;
    [SerializeField] private Text _enchantedIronText;
    [SerializeField] private Text _magicEssenceText;
    [SerializeField] private Text _takenArtifactsOnLevelText;
    [SerializeField] private Text _allTakenArtifactsText;

    [Header("GameObject Panel")]
    [SerializeField] private GameObject _statsPanel;

    private bool _statsPanelIsActive;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
            _statsPanelIsActive = !_statsPanelIsActive;

        if (_statsPanelIsActive == true)
            _statsPanel.SetActive(true);
        else if (_statsPanelIsActive == false)
            _statsPanel.SetActive(false);

        PrintPlayerStats();
    }

    private void PrintPlayerStats()
    {
        _playerWeaponDamageText.text = $"���� ����: {PlayerWeapon.Damage}";
        _playerAttackCdText.text = $"�������� ����� ������: {Attack.AttackCD}";
        _moveSpeedText.text = $"�������� ������������: {PlayerMove.PlayerSpeed}";
        _playerArmorText.text = $"�����: {Player.PlayerArmor}";
        _magicResistText.text = $"���������� �������������: {Player.MagicResist}";
        _goldText.text = $"������: {Consumables.Gold}";
        _enchantedIronText.text = $"������������ ������: {Consumables.EnchantedIron}";
        _magicEssenceText.text = $"���������� ��������: {Consumables.MagicEssence}";
        _takenArtifactsOnLevelText.text = $"���������� ��������� ���������� �� ������: {LevelController1.TakenArtifactsOnLevel} / {LevelController1.AllArtifactsOnLevel}";
        _allTakenArtifactsText.text = $"����� �������� ����������: {Artifacts.ArtifactsAmount}";
    }
}
