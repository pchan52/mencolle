using UnityEngine;

[System.SerializableAttribute]
public class MstCharacter {
	//Monobehaviour継承しているとエラー マッピング出来ない

	[SerializeField]
	private int
	_id,
	_rarity,
	_maxLebel,
	_growthType,
	_lowerEnergy,
	_upperEnergy,
	_initialCost;

	[SerializeField]
	private string 
	_name,
	_imageID,
	_flavorText;

	//dataを受け取って値を変数に格納
	public void SetFromCSV(string[] data){
		_id = int.Parse (data [0]);
		_name = data [1];
		_imageID = data [2];
		_flavorText = data [3];
		_rarity = int.Parse (data [4]);
		_maxLebel = int.Parse (data [5]);
		_growthType = int.Parse (data [6]);
		_lowerEnergy = int.Parse (data [7]);
		_upperEnergy = int.Parse (data [8]);
		_initialCost = int.Parse (data [9]);
	}

	//読み取り専用のプロパティにする
	public int ID       { get{ return _id; } }
	public int Rarity   { get{ return _rarity; } }
	public int MaxLevel { get{ return _maxLebel; } }
	public int GrowthType   { get{ return _growthType; } }
	public int LowerEnergy  { get{ return _lowerEnergy; } }
	public int UpperEnergy  { get{ return _upperEnergy; } }
	public int InitialCost  { get{ return _initialCost; } }
	public string Name { get{ return _name; } }
	public string ImageID { get{ return _imageID; } }
	public string FlavorText { get{ return _flavorText; } }

	public bool PurchaseAvailable(int currentMoney)
	{
		return (currentMoney < InitialCost) ? false : true;
	}

}
