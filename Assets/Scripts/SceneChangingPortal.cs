using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class SceneChangingPortal : NetworkBehaviour {

    public string nextSceneName;

    public void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag != "Player") {
			return;
		}
		string nextScene = "Scenes/" + nextSceneName;
		NetworkServer.SetAllClientsNotReady();
		GameObject.FindWithTag("NetworkManager")
				.GetComponent<NetworkManager>()
				.ServerChangeScene(nextScene);
	}

	void OnLeveLWasLoaded(int level) {
		Debug.Log("Here");
	}
}
