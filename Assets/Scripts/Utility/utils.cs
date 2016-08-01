using UnityEngine;
using System.Collections.Generic;

public static class utils {

	/** Finds the nearest player to seeker, if there is no player on
	  * the screen it returns null. */
	[System.Obsolete("Use FindNearestObject and pass in the list of players instead.")]
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

	/** Finds the nearest object from list to seeker, if there is no nearest object then it
	  * returns null. */
	public static GameObject FindNearestObject(GameObject seeker, List<GameObject> list) {
		if (list == null || list.Count == 0) {
			return null;
		}

		GameObject nearestObject = list[0];
		float nearestObjectDistance = GetDistance(nearestObject, seeker);

		foreach (GameObject obj in list) {
			float currentDistance = GetDistance(obj, seeker);
			if (nearestObjectDistance > currentDistance) {
				nearestObject = obj;
				nearestObjectDistance = currentDistance;
			}
		}
		return nearestObject;
	}

	/** Finds the nearest object from list to seeker, if there is no nearest object then it
	  * returns null. */
	public static GameObject FindNearestObject(GameObject seeker, HashSet<GameObject> list) {
		return FindNearestObject(seeker, new List<GameObject>(list));
	}

	/** Returns the true distance between game objects X and Y. */
	public static float GetDistance(GameObject x, GameObject y) {
		if (x == null || y == null) {
			return 999999;
		}
		return Vector2.Distance(x.transform.position, y.transform.position);
	}

	/** Shuffles the given array in place. */
	public static void Shuffle<T>(ref T[] arrayToBeShuffled) {
		for (int i = 0; i < arrayToBeShuffled.Length; i++) {
			T temp = arrayToBeShuffled[i];
			int r = Random.Range(i, arrayToBeShuffled.Length);
			arrayToBeShuffled[i] = arrayToBeShuffled[r];
			arrayToBeShuffled[r] = temp;
		}
	}
}
