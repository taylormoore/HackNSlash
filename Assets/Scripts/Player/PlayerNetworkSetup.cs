using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerNetworkSetup : NetworkBehaviour {

	void Start () {
	   if (isLocalPlayer) {
            GetComponent<PlayerMovement>().enabled = true;
            GetComponent<PlayerInput>().enabled = true;
       }
       PlayerReference.AddPlayer(gameObject);
	}
}
