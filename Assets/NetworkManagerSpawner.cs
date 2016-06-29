using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkManagerSpawner : NetworkBehaviour {

	public GameObject[] enemiesToSpawn;
	public GameObject[] enemySpawnLocations;
	public Transform[] playerSpawnLocations;

	bool spawned = false;
	void FixedUpdate() {
		if (!spawned && NetworkServer.active) {
			CmdSpawnEnemies();
			MovePlayers();
			spawned = true;
		}
	}

	void CmdSpawnEnemies() {
		utils.Shuffle(ref enemySpawnLocations);
		for (int i = 0; i < enemiesToSpawn.Length; i++) {
			GameObject enemy = (GameObject) Instantiate(enemiesToSpawn[i],
				enemySpawnLocations[i].transform.position,
				enemySpawnLocations[i].transform.rotation);
			NetworkServer.Spawn(enemy);
		}
	}

	void MovePlayers() {
		utils.Shuffle(ref playerSpawnLocations);
		List<GameObject> players = PlayerReference.GetPlayers();
		for (int i = 0; i < players.Count; i++) {
			players[i].SendMessage("SceneChange");
			players[i].transform.position = playerSpawnLocations[i].position;
		}
	}
}
