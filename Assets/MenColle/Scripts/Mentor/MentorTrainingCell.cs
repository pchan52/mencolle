using UnityEngine;
using UnityEngine.UI;
using UniRx;

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
	
	private User User { get { return GameManager.instance.User; } }

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
		
		_levelUpButton.onClick.AddListener(() =>
		{
			// 追記
			var cost = CulcLevelUpCost();
			if (User.Money.Value < cost) return;
			if (_characterdata.IsLevelMax) return;
			_characterdata.LevelUp();
			User.ConsumptionLevelUpCost(cost);
			UpdateValue();
		});
		
		_disctiptionButton.onClick.AddListener(() => {
			// Descriptionを表示させるところを作ってないのでまだ
		});

		_vrButton.onClick.AddListener(() => {
			// VRViewを作ってないのでまだ
		});

		// 所持金のIntReactiveProperty化で対応しておく予定の部分
		if (User.Money.Value < CulcLevelUpCost()) _levelUpButtonGroup.alpha = 0.5f;
		User.Money.Subscribe(value => {
			if (_characterdata.IsLevelMax) return;
			UpdateValue();
		});
	}

	private int CulcLevelUpCost()
	{
		return MasterDataManager.instance.GetConsumptionMoney (_characterdata);
	}

	public void UpdateValue()
	{
//		var mastercharacter = _characterdata.Master;
		_levelLabel.text = "Lv." + _characterdata.Level;
		_productivityLabel.text = "生産性 : ¥" + _characterdata.Power + "/tap";
		var cost = CulcLevelUpCost();
		_costLabel.text = "¥" + cost;
		if (User.Money.Value < cost)
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
