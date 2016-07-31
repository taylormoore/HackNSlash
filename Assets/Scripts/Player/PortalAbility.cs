using Rewired;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class PortalAbility : NetworkBehaviour {

    [SerializeField]
    GameObject portal;

    GameObject myPortal;
	List<string> noPortalScenes = new List<string>();
    private Player player;

    float lastPortalCast;
	[SerializeField]
    float portalCooldown;

    void Start() {
        player = ReInput.players.GetPlayer(0);
        lastPortalCast = Time.time;
		noPortalScenes.Add("HubWorld");
		noPortalScenes.Add("Scenes/HubWorld");
    }

    void Update() {
        if (player.GetButtonDown("Portal") && Time.time > lastPortalCast + portalCooldown
			&& !noPortalScenes.Contains(SceneManager.GetActiveScene().name)) {
            CmdCastPortal();
        }
    }


    // Creates portal if we are not in hub world  and if cooldown is up.
    [Command]
    void CmdCastPortal() {
		if (myPortal != null) {
			Destroy(myPortal);
		}
		myPortal = Instantiate(portal, new Vector2(transform.position.x,
			transform.position.y + 2), transform.rotation) as GameObject;
		lastPortalCast = Time.time;
		NetworkServer.Spawn(myPortal);
    }
}


