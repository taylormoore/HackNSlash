using UnityEngine;
using System.Collections.Generic;

public static class utils {

	public static GameObject FindNearestPlayer(GameObject seeker) {
        List<GameObject> players = PlayerReference.GetPlayers();

        if (players.Count == 0) {
            return null;
        }

        GameObject nearestPlayer = players[0];
        float nearestPlayerDistance = Vector2.Distance(
            nearestPlayer.transform.position, seeker.transform.position);

        foreach (GameObject player in players) {
            float currentDistance = Vector2.Distance(player.transform.position,
                seeker.transform.position);
            if (nearestPlayerDistance > currentDistance) {
                nearestPlayer = player;
                nearestPlayerDistance = currentDistance;
            }
        }
        return nearestPlayer;
    }
}
