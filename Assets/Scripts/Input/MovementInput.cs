/* Handles input for movement of player character. This is attached to the 
 * static Player Input game object that persists between all scenes. */

using Rewired;
using UnityEngine;

public class MovementInput : MonoBehaviour {

    private Player player;
    public static float horizontalAxis, verticalAxis = 0f;

    void Start() {
        player = ReInput.players.GetPlayer(0);
    }

    void Update() {
        DetectMovementInput();
    }

    void DetectMovementInput() {
        horizontalAxis = player.GetAxisRaw("MoveHorizontal");

        verticalAxis = player.GetAxisRaw("MoveVertical");
    }
}
