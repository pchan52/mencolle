using System;
using System.Collections.Generic;
//using System.Linq;
using UnityEngine;

[Serializable]
public class User
{

	[SerializeField] private int _money;
	[SerializeField] private List<Character> _characters;

	public int Money {
		get { return _money; }
	}

	public List<Character> Characters
	{
		get { return _characters ?? (_characters = new List<Character>()); }
	}
	
	public Character NewCharacter(MstCharacter data)
	{
		var uniqueId = (Characters.Count == 0) ? 1 : _characters[_characters.Count - 1].UniqueID + 1;
		var chara = new Character(uniqueId, data);
		_characters.Add(chara);
		_money -= data.InitialCost;
		return chara;
	}
}
