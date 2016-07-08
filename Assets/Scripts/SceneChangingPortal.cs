using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class SceneChangingPortal : NetworkBehaviour {

    public string nextSceneName;

    public void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
			GameObject[] players = PlayerReference.GetPlayers().ToArray();
			RpcChangeScene();
			for (int i = 0; i < NetworkServer.connections.Count; i++) {
				NetworkServer.SetClientReady(NetworkServer.connections[i]);
			}
		}
    }

	[ClientRpc]
	void RpcChangeScene() {
		string nextScene = "Scenes/" + nextSceneName;
		SceneManager.LoadScene(nextScene);
		GameObject.FindWithTag("NetworkManager")
				.GetComponent<NetworkManager>()
				.ServerChangeScene(nextScene);

	}
}
