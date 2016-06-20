using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

[NetworkSettings(channel=1,sendInterval=0.2f)]
public class EnemyStatus : NetworkBehaviour {

	[SyncVar]
    [SerializeField]
	private int enemyHealth;

    EnemyUI enemyUI;

    void Awake() {
        enemyUI = GetComponent<EnemyUI>();
        enemyUI.SetHealthUI(enemyHealth);
    }

	public void ApplyDamage(int value) {
        enemyHealth -= value;
        Debug.Log("Enemy Health: " + enemyHealth);
        enemyUI.SetHealthUI(enemyHealth);
	}

	public int GetHealth() {
		return enemyHealth;
	}
}
