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
		GameObject.FindWithTag("NetworkManager")
				.GetComponent<NetworkManager>()
				.ServerChangeScene(nextScene);
		//for (int i = 0; i < NetworkServer.connections.Count; i++) {
		//	NetworkServer.SetClientReady(NetworkServer.connections[i]);
		//}
	}

	void OnLeveLWasLoaded(int level) {
		Debug.Log("Here");
	}
}
