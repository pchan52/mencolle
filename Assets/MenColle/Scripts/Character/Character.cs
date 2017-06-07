using System;
using System.Collections;
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
			int power = 1;
			switch (Master.GrowthType)
			{
				case 1:
					power = (int) (-(Master.UpperEnergy - Master.LowerEnergy) *
					               Math.Pow((_level - Master.MaxLevel) / (1 - Master.MaxLevel), 2) + Master.UpperEnergy);
					break;
				case 2:
					power = 
						Master.LowerEnergy 
						+ ( 
							(_level - 1) 
							* (Master.UpperEnergy - Master.LowerEnergy) 
							/ (Master.MaxLevel - 1) 
						);
					break;
				case 3:
					power = (int) ((Master.UpperEnergy - Master.LowerEnergy) *
					               Math.Pow((_level - Master.MaxLevel) / (Master.MaxLevel-1), 2) + Master.LowerEnergy);
					break;
			}
		
			return power;
		}
	}

	public bool IsLevelMax
	{
		get { return (_level >= Master.MaxLevel) ? true : false; }
	}

	public void LevelUp()
	{
		_level += 1;
	}
}
