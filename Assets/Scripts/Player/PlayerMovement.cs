using UnityEngine;
using UnityEngine.Networking;

public class PlayerMovement : NetworkBehaviour {

    public Sprite facingUp, facingDown, facingLeft, facingRight;
    public float movementSpeed;
    Animator animator;

    void Start() {
        if (isLocalPlayer) {
            animator = GetComponent<Animator>();
        }
    }

    void Update() {
        if (isLocalPlayer && animator != null) {
            if (MovementInput.horizontalAxis > .35f) {
                animator.SetInteger("direction", 1);
            }
            else if (MovementInput.horizontalAxis < -.35f) {
                animator.SetInteger("direction", 0);
            }
            if (MovementInput.verticalAxis > .35f) {
                animator.SetInteger("direction", 2);
            }
            else if (MovementInput.verticalAxis < -.35f) {
                animator.SetInteger("direction", 3);
            }
        }
        transform.Translate(Vector2.up * Time.deltaTime * MovementInput.verticalAxis * movementSpeed);
        transform.Translate(Vector2.right * Time.deltaTime * MovementInput.horizontalAxis * movementSpeed);
    }
}
