using UnityEngine;
using System.Collections;

public class GameManager
	: SingletonMonoBehaviour<GameManager>
{
	private void Start()
	{
		MasterDataManager.instance.LoadData ();
	}

	public static void Log (object log)
	{
		if (Debug.isDebugBuild)
		{
			Debug.Log(log);
		}
	}
}