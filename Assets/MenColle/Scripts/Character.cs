using UnityEngine;

[System.SerializableAttribute]
public class Character {

	[SerializeField] private int _uid, _masterId, _level;

	public int UniqueId { get {return _uid;} }
	public int MasterId { get {return _masterId;} }
	public int Level { get {return _level;} }

	public Character(int uniqueId, MstCharacter chr)
	{
		_uid = uniqueId;
		_masterId = chr.ID;
		_level = 1;
	}
}
