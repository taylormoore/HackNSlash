using Rewired;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Player player;

    public static bool inputDisabled, attackRight, attackLeft, attackUp, attackDown = false;
    public static float horizontalAxis, verticalAxis = 0f;

    void Start() {
        player = ReInput.players.GetPlayer(0);
    }

    void Update() {
        DetectInput();
    }

    void DetectInput() {
        horizontalAxis = player.GetAxisRaw("Move Horizontal");

        verticalAxis = player.GetAxisRaw("Move Vertical");

        // Basic attack input.
        if (player.GetAxisRaw("Attack Horizontal") > 0) {
            attackRight = true;
        } else {
            attackRight = false;
        }

        if (player.GetAxisRaw("Attack Horizontal") < 0) {
            attackLeft = true;
        } else {
            attackLeft = false;
        }

        if (player.GetAxisRaw("Attack Vertical") > 0) {
            attackUp = true;
        } else {
            attackUp = false;
        }

        if (player.GetAxisRaw("Attack Vertical") < 0) {
            attackDown = true;
        } else {
            attackDown = false;
        }
    }
}
