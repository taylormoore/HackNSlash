using UnityEngine;
using System.Collections.Generic;

public static class PlayerReference {

	static List<GameObject> players = new List<GameObject>();

	public static void AddPlayer(GameObject player) {
		players.Add(player);
		Debug.Log(player + " added to players list.");
	}

	public static void RemovePlayer(GameObject player) {
		players.Remove(player);
		Debug.Log(player + " removed from players list.");
	}

	public static List<GameObject> GetPlayers() {
		return players;
	}

	public static bool PlayersArePresent() {
		if (players.Count > 0) {
			return true;
		} else {
			return false;
		}
	}
}
