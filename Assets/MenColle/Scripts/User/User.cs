using System;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;

[Serializable]
public class User
{

	[SerializeField] private IntReactiveProperty _money;
	[SerializeField] private List<Character> _characters;

	public IntReactiveProperty Money {
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
		_money.Value -= data.InitialCost;
		return chara;
	}
	
	// 追記部分
	public int ProductivityPerTap
	{
		get 
		{ 
			int sum = _characters.Sum(c => c.Power);
			return (sum == 0) ? 1 : sum; 
		}
	}
	
	public void AddMoney(int cost)
	{
		_money.Value += cost;
	}
}
