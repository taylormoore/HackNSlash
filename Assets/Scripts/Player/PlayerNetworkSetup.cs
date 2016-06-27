﻿using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerNetworkSetup : NetworkBehaviour {

	void Start () {
	   if (isLocalPlayer) {
            GetComponent<PlayerMovement>().enabled = true;
            GetComponent<PlayerInput>().enabled = true;
            GetComponent<PlayerBasicAttack>().enabled = true;
            Camera2DFollow camera = Camera.main.GetComponent<Camera2DFollow>();
            camera.enabled = true;
            camera.target = gameObject.transform;
       }
       PlayerReference.AddPlayer(gameObject);
	}
}
