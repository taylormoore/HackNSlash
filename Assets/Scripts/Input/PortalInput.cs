/* Handles input for casting a portal back to town. This is attached to the 
 * static Player Input game object that persists between all scenes. */

using Rewired;
using UnityEngine;

public class PortalInput : MonoBehaviour {

    private Player player;
    public static bool castPortal = false;

    void Start() {
        player = ReInput.players.GetPlayer(0);
    }

    void Update() {
        if (player.GetButtonDown("Portal")) {
            castPortal = true;
        }
        else {
            castPortal = false;
        }
    }
}

