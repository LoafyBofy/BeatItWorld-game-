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
        _playerWeaponDamageText.text = $"Урон меча: {PlayerWeapon.Damage}";
        _playerAttackCdText.text = $"Задержка перед атакой: {Attack.AttackCD}";
        _moveSpeedText.text = $"Скорость передвижения: {PlayerMove.PlayerSpeed}";
        _playerArmorText.text = $"Броня: {Player.PlayerArmor}";
        _magicResistText.text = $"Магическое сопротивление: {Player.MagicResist}";
        _goldText.text = $"Золото: {Consumables.Gold}";
        _enchantedIronText.text = $"Зачарованное железо: {Consumables.EnchantedIron}";
        _magicEssenceText.text = $"Магическая эссенция: {Consumables.MagicEssence}";
        _takenArtifactsOnLevelText.text = $"Количество собранных артефактов на уровне: {LevelController1.TakenArtifactsOnLevel} / {LevelController1.AllArtifactsOnLevel}";
        _allTakenArtifactsText.text = $"Всего собранно артефактов: {Artifacts.ArtifactsAmount}";
    }
}
