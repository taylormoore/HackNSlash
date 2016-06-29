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
            if (PlayerInput.horizontalAxis > .35f) {
                animator.SetInteger("direction", 1);
            }
            else if (PlayerInput.horizontalAxis < -.35f) {
                animator.SetInteger("direction", 0);
            }
            if (PlayerInput.verticalAxis > .35f) {
                animator.SetInteger("direction", 2);
            }
            else if (PlayerInput.verticalAxis < -.35f) {
                animator.SetInteger("direction", 3);
            }
        }
        transform.Translate(Vector2.up * Time.deltaTime * PlayerInput.verticalAxis * movementSpeed);
        transform.Translate(Vector2.right * Time.deltaTime * PlayerInput.horizontalAxis * movementSpeed);
    }
}
