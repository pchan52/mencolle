using UnityEngine;
using UnityEngine.UI;

public class MentorTrainingCell : MonoBehaviour
{

	[SerializeField] private Image _iconImage;

	[SerializeField] private Text
		_nameLavel,
		_rarityLabel,
		_levelLabel,
		_productivityLabel,
		_costLabel;

	[SerializeField] private Button
		_levelUpButton,
		_disctiptionButton,
		_vrButton;

	[SerializeField] private CanvasGroup _levelUpButtonGroup;

	private Character _characterdata;

	public void SetValue(Character data)
	{
		//masterデータからの情報
		var mastercharacter = data.Master;
		_characterdata = data;
		_iconImage.sprite = Resources.Load<Sprite>("Face/" + mastercharacter.ImageID);
		_nameLavel.text = mastercharacter.Name;
		_rarityLabel.text = "";
		for (var i = 0; i < mastercharacter.Rarity; i++)
		{
			_rarityLabel.text += "★";
		}
		
		//現キャラクターの情報
		UpdateValue();
	}

	private int CulcLevelUpCost()
	{
		return 100;
	}

	public void UpdateValue()
	{
//		var mastercharacter = _characterdata.Master;
		_levelLabel.text = "Lv." + _characterdata.Level;
		_productivityLabel.text = "生産性 : ¥" + _characterdata.Power + "/tap";
		var cost = CulcLevelUpCost();
		_costLabel.text = "¥" + cost;
		if (true)
		{
			_levelUpButtonGroup.alpha = 0.5f;
		}else
		{
			_levelUpButtonGroup.alpha = 1.0f;
		}
		if (_characterdata.IsLevelMax)
		{
			_levelUpButtonGroup.alpha = 0.5f;
			_costLabel.text = "Level Max";
		}

	}
}	
