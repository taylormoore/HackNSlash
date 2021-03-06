﻿using UnityEngine;
using UnityEngine.Networking;

public class PlayerNetworkSetup : NetworkBehaviour {

	void Start() {
		if (isLocalPlayer) {
			GetComponent<PlayerMovement>().enabled = true;
			GetComponent<PlayerBasicAttack>().enabled = true;
			GetComponent<PortalAbility>().enabled = true;
			GetComponent<PlayerInteract>().enabled = true;
			Camera2DFollow camera = Camera.main.GetComponent<Camera2DFollow>();
			camera.enabled = true;
			camera.target = gameObject.transform;
		}
		PlayerReference.AddPlayer(gameObject);
	}

	public void SceneChange() {

	}
}
