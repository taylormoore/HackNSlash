using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	[SerializeField]
    int movementSpeed;

    GameObject nearestPlayer;

    void Update() {
        MoveTowardsNearestPlayer();
    }

    void FixedUpdate() {
        nearestPlayer = utils.FindNearestPlayer(gameObject);
    }

    void MoveTowardsNearestPlayer() {
        Debug.Log("nearestPlayer: " + nearestPlayer);
        if (nearestPlayer == null) {
            return;
        }

        transform.position = Vector2.MoveTowards(transform.position, nearestPlayer.transform.position, .02f);
    }


}
