using UnityEngine.Networking;

public class EnemyStatus : NetworkBehaviour {

    [SyncVar(hook = "SetHealth")]
    public int enemyHealth;

    EnemyUI enemyUI;

    void OnEnable() {
        enemyUI = GetComponent<EnemyUI>();
        enemyUI.SetHealthUI(enemyHealth);
    }

    public void SetHealth(int health) {
        enemyHealth = health;
        enemyUI.SetHealthUI(enemyHealth);
    }

    public void ApplyDamage(int value) {
		if (!isServer) {
			return;
		}
        enemyHealth -= value;
        enemyUI.SetHealthUI(enemyHealth);
        if (enemyHealth <= 0) {
			Death();
        }
    }

	public void Death() {
		gameObject.SendMessage("DropItem");
		NetworkServer.Destroy(gameObject);
	}

    public int GetHealth() {
        return enemyHealth;
    }
}
