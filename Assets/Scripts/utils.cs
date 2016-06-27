using UnityEngine;
using System.Collections.Generic;

public static class utils {

	public static GameObject FindNearestPlayer(GameObject seeker) {
        List<GameObject> players = PlayerReference.GetPlayers();

        if (players.Count == 0) {
            return null;
        }

        GameObject nearestPlayer = players[0];
        float nearestPlayerDistance = GetDistance(nearestPlayer, seeker);

        foreach (GameObject player in players) {
            float currentDistance = GetDistance(player, seeker);
            if (nearestPlayerDistance > currentDistance) {
                nearestPlayer = player;
                nearestPlayerDistance = currentDistance;
            }
        }
        return nearestPlayer;
    }

    public static float GetDistance(GameObject x, GameObject y) {
        return Vector2.Distance(x.transform.position, y.transform.position);
    }

    public static int[] Shuffle(int[] arrayToBeShuffled) {
        for (int i = 0; i < arrayToBeShuffled.Length; i++) {
            int temp = arrayToBeShuffled[i];
            int r = Random.Range(i, arrayToBeShuffled.Length);
            arrayToBeShuffled[i] = arrayToBeShuffled[r];
            arrayToBeShuffled[r] = temp;
        }
        return arrayToBeShuffled;
    }
}
