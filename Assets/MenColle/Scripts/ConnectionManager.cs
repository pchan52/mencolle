using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ConnectionManager : SingletonMonoBehaviour<ConnectionManager> {

	public void ConnectionAPI (
		string url,
		UnityAction<string> onFinish = null,
		UnityAction<string> errorFinish = null
	) {
		StartCoroutine(ConnectionAPICoroutine(url, onFinish, errorFinish));
	}

	private IEnumerator ConnectionAPICoroutine (
		string url,
		UnityAction<string> onFinish = null,
		UnityAction<string> errorFinish = null
	) {
		WWW www = new WWW(url);
//		GameManager.Log("通信開始 : " + www.url);
		yield return www;
		if (www.error == null) {
//			GameManager.Log( "url:"+ www.url + "\nSuccess : " + www.text );
			if (onFinish != null) {
				onFinish( www.text );
			}
		}
		else {
//			GameManager.Log("url:"+ www.url + "\nFaild : " + www.error);
			if (errorFinish != null) {
				errorFinish( www.error );
			}
		}
	}

}
