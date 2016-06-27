using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;

public class NetworkManagerSpawner : NetworkBehaviour {

    public GameObject[] enemiesToSpawn;
    public GameObject[] enemySpawnLocations;
    public Transform[] playerSpawnLocations;
    private int[] playerSpawnLocationIndicies;
    private int[] enemySpawnLocationIndicies;
	// Use this for initialization
    bool spawned = false;
	void FixedUpdate() {
        if (!spawned && NetworkServer.active) {
            CmdSpawnEnemies();
            MovePlayers();
            spawned = true;
        }
        
	}

    void CmdSpawnEnemies() {
        enemySpawnLocationIndicies = new int[enemySpawnLocations.Length];
        for (int i = 0; i < enemySpawnLocations.Length; i++) {
            enemySpawnLocationIndicies[i] = i;
        }
        utils.Shuffle(enemySpawnLocationIndicies);
        for (int i = 0; i < enemiesToSpawn.Length; i++) {
            GameObject enemy = (GameObject) Instantiate(enemiesToSpawn[i],
                enemySpawnLocations[enemySpawnLocationIndicies[i]].transform.position,
                enemySpawnLocations[enemySpawnLocationIndicies[i]].transform.rotation);
            NetworkServer.Spawn(enemy);
        }
    }
	
	void MovePlayers() {
        Debug.Log("Here 2");
        playerSpawnLocationIndicies = new int[playerSpawnLocations.Length];
        for (int i = 0; i < playerSpawnLocations.Length; i++) {
            playerSpawnLocationIndicies[i] = i;
        }
        utils.Shuffle(playerSpawnLocationIndicies);
        List<GameObject> players = PlayerReference.GetPlayers();
        for (int i = 0; i < players.Count; i++) {
            players[i].SendMessage("SceneChange");
            players[i].transform.position = playerSpawnLocations[playerSpawnLocationIndicies[i]].position;
        }
    }
}
