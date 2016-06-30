/* Handles input for abilities of player character. This is attached to the 
 * static Player Input game object that persists between all scenes. */

using Rewired;
using UnityEngine;

public class AbilityInput : MonoBehaviour {

    private Player player;

    void Start() {
        player = ReInput.players.GetPlayer(0);
    }

    void Update() {
        DetectAbilityInput();
    }

    void DetectAbilityInput() {
        //TO DO
        player.GetButtonDown("Ugh"); // This is to stop the annoying warnings.
    }
}
