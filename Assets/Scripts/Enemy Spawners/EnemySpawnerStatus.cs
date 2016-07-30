using UnityEngine.Networking;

public class EnemySpawnerStatus : NetworkBehaviour {

    [SyncVar(hook = "SetHealth")]
    public int spawnerHealth;

    EnemySpawnerUI enemySpawnerUI;

    void OnEnable() {
        enemySpawnerUI = GetComponent<EnemySpawnerUI>();
        enemySpawnerUI.SetHealthUI(spawnerHealth);
    }

    public void SetHealth(int health) {
        spawnerHealth = health;
        enemySpawnerUI.SetHealthUI(spawnerHealth);
    }

    public void ApplyDamage(int value) {
        spawnerHealth -= value;
        enemySpawnerUI.SetHealthUI(spawnerHealth);
        if (spawnerHealth <= 0) {
            NetworkServer.Destroy(gameObject);
        }
    }

    public int GetHealth() {
        return spawnerHealth;
    }
}
