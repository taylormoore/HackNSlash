using UnityEngine;
using UnityEngine.Networking;

public class EnemySpawner : NetworkBehaviour {

    [SerializeField]
    GameObject enemyToSpawn;

    void Start() {
        CmdSpawnEnemy();
    }

    [Command]
    void CmdSpawnEnemy() {
        if (enemyToSpawn) {
            GameObject newEnemy = Instantiate(enemyToSpawn, transform.position, transform.rotation) as GameObject;
            NetworkServer.Spawn(newEnemy);
        }
    }

}
