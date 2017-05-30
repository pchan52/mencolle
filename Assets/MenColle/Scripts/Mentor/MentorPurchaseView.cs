using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MentorPurchaseView : MonoBehaviour {

	[SerializeField] private GameObject _mentorPurchaseCellPrefab;
	[SerializeField] private Transform _scrollContent;

	public void SetCells()
	{
		var characters = MasterDataManager.instance.CharacterTable;
		characters.ForEach(c => {
			var obj = Instantiate(_mentorPurchaseCellPrefab) as GameObject;
			obj.transform.SetParentWithReset(_scrollContent);
			var cell = obj.GetComponent<MentorPurchaseCell>();
			cell.SetValue(c);
		});
	}

}
