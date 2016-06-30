using UnityEngine;
using UnityEngine.Networking;

public class SceneChangingPortal : MonoBehaviour {

    public string nextSceneName;

    public void OnTriggerEnter2D(Collider2D other) {
        string nextScene = "Scenes/" + nextSceneName;
        if (other.gameObject.tag == "Player") {
			GameObject[] players = PlayerReference.GetPlayers().ToArray();
            GameObject.FindWithTag("NetworkManager")
                .GetComponent<NetworkManager>()
                .ServerChangeScene(nextScene);
			for (int i = 0; i < players.Length; i++) {
				
			}
		}
    }
}
