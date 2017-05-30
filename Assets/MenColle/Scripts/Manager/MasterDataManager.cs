﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MasterDataManager : SingletonMonoBehaviour<MasterDataManager> {

	[SerializeField] 
	private List<MstCharacter> characterTable = new List<MstCharacter>();
	public List<MstCharacter> CharacterTable { get { return characterTable; } }

	const string csvurl = "https://docs.google.com/spreadsheets/d/1mYUT577B26EFcw9ifaXWbMMoUHvbkR_NyHYdh3dc94k/pub?gid=605974578&single=true&output=csv";

	// GameManagerから呼んでもらう
	public void LoadData()
	{
		ConnectionManager.instance.ConnectionAPI(
			csvurl, 
			(string result) => {
				var csv = CSVReader.SplitCsvGrid(result);
				for (int i=1; i<csv.GetLength(1)-1; i++) 
				{
					var data = new MstCharacter();
					data.SetFromCSV( GetRaw(csv, i) );
					characterTable.Add(data);
				}
				var purchaseView = GameObject.FindObjectOfType<MentorPurchaseView>();
				purchaseView.SetCells();
			}
		);
	}


	private string[] GetRaw(string[,] csv, int row){
		string[] data = new string[csv.GetLength (0)];
		for (int i =0; i<csv.GetLength(0); i++){
			data[i] = csv[i,row];
		}
		return data;
	}
}