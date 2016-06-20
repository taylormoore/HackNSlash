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
        if (nearestPlayer == null) {
            return;
        }

        transform.position = Vector2.MoveTowards(transform.position, nearestPlayer.transform.position, .02f);
    }


}
