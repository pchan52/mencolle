using UnityEngine;
using System.Collections;

public class GameManager
	: SingletonMonoBehaviour<GameManager>
{
	[SerializeField] private User userData = new User();
	public User User { get { return userData; } }
	
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