using UnityEngine;
using System.Collections;

public class GameManager
	: SingletonMonoBehaviour<GameManager>
{
	private void Start()
	{
		MasterDataManager.instance.LoadData(() => 
			{
				var purchaseView = GameObject.FindObjectOfType<MentorPurchaseView>();
				purchaseView.SetCells();
			});
	}

	public static void Log (object log)
	{
		if (Debug.isDebugBuild)
		{
			Debug.Log(log);
		}
	}
}