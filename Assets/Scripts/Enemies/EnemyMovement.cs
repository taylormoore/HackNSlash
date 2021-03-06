﻿using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    [SerializeField]
    float movementSpeed;

    GameObject nearestPlayer;

    void Update() {
        MoveTowardsNearestPlayer();
    }

    void FixedUpdate() {
        nearestPlayer = utils.FindNearestObject(gameObject, PlayerReference.GetPlayers());
    }

    void MoveTowardsNearestPlayer() {
        if (nearestPlayer == null) {
            return;
        }

        transform.position = Vector2.MoveTowards(transform.position, nearestPlayer.transform.position, movementSpeed);
    }


}
