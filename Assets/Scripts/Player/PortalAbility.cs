using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class PortalAbility : NetworkBehaviour {

	[SerializeField]
	GameObject portal;

	GameObject myPortal;

	float lastPortalCast;
	float portalCooldown;

	void Start() {
		lastPortalCast = Time.time;
		portalCooldown = 3f;
	}

	void Update() {
		if (PortalInput.castPortal) {
			CmdCastPortal();
		}
	}

	// Creates portal if we are not in hub world and if cooldown is up.
	[Command]
	void CmdCastPortal() {
		if (SceneManager.GetActiveScene().name == "HubWorld") {
			Debug.Log("Cannot cast portal in hub world");
			return;
		}
		if (Time.time > lastPortalCast + portalCooldown) {
			if (myPortal != null) {
				Destroy(myPortal);
			}
			myPortal = Instantiate(portal, new Vector2(transform.position.x,
				transform.position.y + 4), transform.rotation) as GameObject;
			lastPortalCast = Time.time;
			NetworkServer.Spawn(myPortal);
		} else {
			Debug.Log("Portal is on cooldown.");
		}
	}

	[Command]
	void CmdRemovePreviousPortal() {
		//TO DO
	}
}


