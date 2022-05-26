using UnityEngine;
using UnityEngine.UI;

public class SkillExplorePanel : MonoBehaviour
{
    [Header("SelectedColumText")]
    [SerializeField] private Text[] _selectColumTexts;
    [Header("ExploredColumText")]
    [SerializeField] private Text[] _exploreColumTexts;

    private short _selectedText = 1;

    #region SkillIsExplored

    private bool _fireballIsExplored = false;
    private bool _stunwaveIsExplored = false;
    private bool _rageIsExplored = false;
    private bool _accelerationIsExplored = false;

    #endregion

    private void Update()
    {
        SwitchText();
        ExploreSkill();
        SetSkill();
        CheckTextForActiveSkills();

        if (Input.GetKeyDown(KeyCode.Escape))
            gameObject.SetActive(false);
    }
    private void SetSkill()
    {
        if (Input.GetKeyDown(KeyCode.Z) && _selectedText == 1 && _fireballIsExplored == true)
        {
            Skills.SkillZ = 1;
            _selectColumTexts[0].text = "Ёкипированно (Z)";
        }
        else if (Input.GetKeyDown(KeyCode.Z) && _selectedText == 3 && _stunwaveIsExplored == true)
        {
            Skills.SkillZ = 2;
            _selectColumTexts[1].text = "Ёкипированно (Z)";
        }
        else if (Input.GetKeyDown(KeyCode.Z) && _selectedText == 5 && _rageIsExplored == true)
        {
            Skills.SkillZ = 3;
            _selectColumTexts[2].text = "Ёкипированно (Z)";
        }
        else if (Input.GetKeyDown(KeyCode.Z) && _selectedText == 7 && _accelerationIsExplored == true)
        {
            Skills.SkillZ = 4;
            _selectColumTexts[3].text = "Ёкипированно (Z)";
        }
        // ---
        if (Input.GetKeyDown(KeyCode.X) && _selectedText == 1 && _fireballIsExplored == true)
        {
            Skills.SkillX = 1;
            _selectColumTexts[0].text = "Ёкипированно (X)";
        }
        else if (Input.GetKeyDown(KeyCode.X) && _selectedText == 3 && _stunwaveIsExplored == true)
        {
            Skills.SkillX = 2;
            _selectColumTexts[1].text = "Ёкипированно (X)";
        }
        else if (Input.GetKeyDown(KeyCode.X) && _selectedText == 5 && _rageIsExplored == true)
        {
            Skills.SkillX = 3;
            _selectColumTexts[2].text = "Ёкипированно (X)";
        }
        else if (Input.GetKeyDown(KeyCode.X) && _selectedText == 7 && _accelerationIsExplored == true)
        {
            Skills.SkillX = 4;
            _selectColumTexts[3].text = "Ёкипированно (X)";
        }
    }

    private void CheckTextForActiveSkills()
    {
        if (Skills.SkillZ != 1 && Skills.SkillX != 1)
            _selectColumTexts[0].text = "Ёкипировать";
        if (Skills.SkillZ != 2 && Skills.SkillX != 2)
            _selectColumTexts[1].text = "Ёкипировать";
        if (Skills.SkillZ != 3 && Skills.SkillX != 3)
            _selectColumTexts[2].text = "Ёкипировать";
        if (Skills.SkillZ != 4 && Skills.SkillX != 4)
            _selectColumTexts[3].text = "Ёкипировать";
    }

    private void ExploreSkill()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _selectedText == 2 && _fireballIsExplored == false && Consumables.MagicEssence >= 10)
        {
            Consumables.MagicEssence -= 10;
            _fireballIsExplored = true;
            _exploreColumTexts[0].text = "»зучено";
        }
        if (Input.GetKeyDown(KeyCode.Space) && _selectedText == 4 && _stunwaveIsExplored == false && Consumables.MagicEssence >= 10)
        {
            Consumables.MagicEssence -= 10;
            _stunwaveIsExplored = true;
            _exploreColumTexts[1].text = "»зучено";
        }
        if (Input.GetKeyDown(KeyCode.Space) && _selectedText == 6 && _rageIsExplored == false && Consumables.MagicEssence >= 10)
        {
            Consumables.MagicEssence -= 10;
            _rageIsExplored = true;
            _exploreColumTexts[2].text = "»зучено";
        }
        if (Input.GetKeyDown(KeyCode.Space) && _selectedText == 8 && _accelerationIsExplored == false && Consumables.MagicEssence >= 10)
        {
            Consumables.MagicEssence -= 10;
            _accelerationIsExplored = true;
            _exploreColumTexts[3].text = "»зучено";
        }
    }

    private void ChangeColor()
    {
        SetTextColorBack();
        switch (_selectedText)
        {
            case 1:
                _selectColumTexts[0].color = Color.white;
                break;
            case 2:
                _exploreColumTexts[0].color = Color.white;
                break;
            case 3:
                _selectColumTexts[1].color = Color.white;
                break;
            case 4:
                _exploreColumTexts[1].color = Color.white;
                break;
            case 5:
                _selectColumTexts[2].color = Color.white;
                break;
            case 6:
                _exploreColumTexts[2].color = Color.white;
                break;
            case 7:
                _selectColumTexts[3].color = Color.white;
                break;
            case 8:
                _exploreColumTexts[3].color = Color.white;
                break;
        }
    }

    private void SetTextColorBack()
    {
        for (int i = 0; i < _selectColumTexts.Length; i++ )
        {
            _selectColumTexts[i].color = Color.black;
            _exploreColumTexts[i].color = Color.black;
        }
    }

    private void SwitchText()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _selectedText++;
            CorrectValues();
            ChangeColor();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _selectedText--;
            CorrectValues();
            ChangeColor();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _selectedText += 2;
            CorrectValues();
            ChangeColor();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _selectedText -= 2;
            CorrectValues();
            ChangeColor();
        }
    }

    private void CorrectValues() 
    {
        if (_selectedText < 1)
            _selectedText = 1;
        if (_selectedText > 8)
            _selectedText = 8;
    }
}
