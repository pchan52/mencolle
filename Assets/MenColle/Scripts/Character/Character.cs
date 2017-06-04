using UnityEngine;

[System.SerializableAttribute]
public class Character {

	[SerializeField] private int _uId, _masterId, _level;

	public int UniqueID { get {return _uId;} }
	public int MasterID { get {return _masterId;} }
	public int Level { get {return _level;} }

	public MstCharacter Master
	{
		get { return MasterDataManager.instance.GetCharacterById(_masterId); }
	}

	public Character(int uniqueID, MstCharacter chr)
	{
		_uId = uniqueID;
		_masterId = chr.ID;
		_level = 1;
	}

	public int Power
	{
		get{
			int power = 
				Master.LowerEnergy 
				+ ( 
					(_level - 1) 
					* (Master.UpperEnergy - Master.LowerEnergy) 
					/ (Master.MaxLevel - 1) 
				);
			return power;
		}
	}

	public bool IsLevelMax
	{
		get { return (_level >= Master.MaxLevel) ? true : false; }
	}
}
