using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerNetworkSetup : NetworkBehaviour {

	// Use this for initialization
	void Start () {
	   if (isLocalPlayer) {
            GetComponent<PlayerMovement>().enabled = true;
            GetComponent<PlayerInput>().enabled = true;
       }
	}
}
