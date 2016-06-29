/* Handles input for basic attacks of player character. This is attached to the 
 * Player Input game object that persists between all scenes. */

using Rewired;
using UnityEngine;

public class BasicAttackInput : MonoBehaviour {

    private Player player;
    public static bool attackRight, attackLeft, attackUp, attackDown = false;

    void Start() {
        player = ReInput.players.GetPlayer(0);
    }

    void Update() {
        DetectAttackInput();
    }

    void DetectAttackInput() {
        if (player.GetAxisRaw("AttackHorizontal") > 0) {
            attackRight = true;
        }
        else {
            attackRight = false;
        }

        if (player.GetAxisRaw("AttackHorizontal") < 0) {
            attackLeft = true;
        }
        else {
            attackLeft = false;
        }

        if (player.GetAxisRaw("AttackVertical") > 0) {
            attackUp = true;
        }
        else {
            attackUp = false;
        }

        if (player.GetAxisRaw("AttackVertical") < 0) {
            attackDown = true;
        }
        else {
            attackDown = false;
        }
    }
}
