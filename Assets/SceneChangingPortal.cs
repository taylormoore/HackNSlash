using UnityEngine;
using UnityEngine.Networking;

public class SceneChangingPortal : MonoBehaviour {

	public string nextSceneName;

	public void OnTriggerEnter2D(Collider2D other) {
		string nextScene = "Scenes/" + nextSceneName;
		if (other.gameObject.tag == "Player") {
			GameObject.FindWithTag("NetworkManager")
				.GetComponent<NetworkManager>()
				.ServerChangeScene(nextScene);
		}
	}
}
