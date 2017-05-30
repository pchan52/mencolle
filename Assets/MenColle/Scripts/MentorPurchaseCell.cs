using UnityEngine;
using UnityEngine.UI;

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

	private bool _isSold = false;
	private MstCharacter _characterData;

	public void SetValue(MstCharacter data)
	{
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
	}
}
