using UnityEngine;
using UnityEngine.Networking;

public class PlayerNetworkSetup : NetworkBehaviour {

    void Start() {
        DontDestroyOnLoad(gameObject);
        if (isLocalPlayer) {
            GetComponent<PlayerMovement>().enabled = true;
            GetComponent<PlayerBasicAttack>().enabled = true;
            GetComponent<PortalAbility>().enabled = true;
            Camera2DFollow camera = Camera.main.GetComponent<Camera2DFollow>();
            camera.enabled = true;
            camera.target = gameObject.transform;
        }
        PlayerReference.AddPlayer(gameObject);
    }

    public void SceneChange() {
        if (isLocalPlayer) {
            Camera2DFollow camera = Camera.main.GetComponent<Camera2DFollow>();
            camera.enabled = true;
            camera.target = gameObject.transform;
        }
    }
}
