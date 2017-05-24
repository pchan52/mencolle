﻿using UnityEngine;

[System.SerializableAttribute]
public class MstCharacter {
	//Monobehaviour継承しているとエラー マッピング出来ない

	[SerializeField]
	private int
	id,
	rarity,
	maxLebel,
	growthType,
	lowerEnergy,
	upperEnergy,
	initialCost;

	[SerializeField]
	private string 
	name,
	imageId,
	flavorText;

	//dataを受け取って値を変数に格納
	public void SetFromCSV(string[] data){
		id = int.Parse (data [0]);
		name = data [1];
		imageId = data [2];
		flavorText = data [3];
		rarity = int.Parse (data [4]);
		maxLebel = int.Parse (data [5]);
		growthType = int.Parse (data [6]);
		lowerEnergy = int.Parse (data [7]);
		upperEnergy = int.Parse (data [8]);
		initialCost = int.Parse (data [9]);
	}

	//読み取り専用のプロパティにする
	public int ID       { get{ return id; } }
	public int Rarity   { get{ return rarity; } }
	public int MaxLevel { get{ return maxLebel; } }
	public int GrowthType   { get{ return growthType; } }
	public int LowerEnergy  { get{ return lowerEnergy; } }
	public int UpperEnergy  { get{ return upperEnergy; } }
	public int InitialCost  { get{ return initialCost; } }
	public string Name { get{ return name; } }
	public string ImageId { get{ return imageId; } }
	public string FlavorText { get{ return flavorText; } }

}
