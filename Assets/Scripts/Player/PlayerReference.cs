using UnityEngine;
using System.Collections.Generic;

public static class PlayerReference {

	static List<GameObject> players = new List<GameObject>();

	/** Adds a player to the list of active players. */
	public static void AddPlayer(GameObject player) {
		players.Add(player);
		Debug.Log(player + " added to players list.");
	}

	/** Removes a player from the list of active players. */
	public static void RemovePlayer(GameObject player) {
		players.Remove(player);
		Debug.Log(player + " removed from players list.");
	}

	/** Returns a list of all active players. */
	public static List<GameObject> GetPlayers() {
		return players;
	}

	/** Refreshes the external player UI to make sure that all 
	  * players see the same external player UI. */
	public static void RefreshPlayersUI() {
		foreach (GameObject player in players) {
			player.SendMessage("UpdateHealthUI");
		}
	}

	/** Returns true iff there are active players. */
	public static bool PlayersArePresent() {
		if (players.Count > 0) {
			return true;
		} else {
			return false;
		}
	}

	/** Returns the host player. */
	public static GameObject GetHost() {
		return players[0];
	}
}
