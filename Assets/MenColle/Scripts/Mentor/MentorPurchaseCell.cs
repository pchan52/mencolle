using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class MentorPurchaseCell : MonoBehaviour
{
	[SerializeField] private Image _iconImage;
	[SerializeField] private Text
	_nameLabel,
	_rarityLabel,
	_flavorTextLabel,
	_productivityLabel,
	_costLabel;

	[SerializeField] private Button _purchaseButton;
	
	[SerializeField] private CanvasGroup buttonGroup;

	private bool _isSold = false;
	private MstCharacter _characterData;

	public void SetValue(MstCharacter data)
	{
		print(data.ImageID);
		_iconImage.sprite = Resources.Load<Sprite>("Face/" + data.ImageID);
		_characterData = data;
		_nameLabel.text = data.Name;
		_rarityLabel.text = "";
		for (int i = 0; i < data.Rarity; i++) {
			_rarityLabel.text += "★"; 
		}
		_flavorTextLabel.text = data.FlavorText;
		_productivityLabel.text = "生産性(lv.1) : " + data.LowerEnergy;
		_costLabel.text = string.Format("¥{0:#,0}", data.InitialCost);

		var user = GameManager.instance.User;
		var ch = user.Characters.Find(c => c.MasterID == data.ID);
		_isSold = (ch == null) ? false : true;
		if (_isSold) SoldView();
		if (!_characterData.PurchaseAvailable(user.Money.Value)) buttonGroup.alpha = 0.5f;
		_purchaseButton.onClick.AddListener(() =>
		{
			if (_isSold) return;
			if (!_characterData.PurchaseAvailable(user.Money.Value)) return;
			_isSold = true;
			SoldView();
			var chara = user.NewCharacter(_characterData);
			PortrateUIManager.instance.MentorTrainingView.AddCharacter(chara);
			AvatarManager.instance.SpawnAvatar(chara);
		});
		
		user.Money.Subscribe(value => {
			if (_isSold) return;
			if (value < data.InitialCost) buttonGroup.alpha = 0.5f;
			else buttonGroup.alpha = 1.0f;
		});
	}
	
	private void SoldView()
	{
		buttonGroup.alpha = 0.5f;
		_costLabel.text = "sold out";	
	}
}
