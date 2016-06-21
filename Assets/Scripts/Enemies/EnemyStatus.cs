using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
public class EnemyStatus : NetworkBehaviour {

	[SyncVar]
	[SyncVar(hook="ApplyDamage")]private int enemyHealth;

    EnemyUI enemyUI;

    void Awake() {
        enemyHealth = 500;
        enemyUI = GetComponent<EnemyUI>();
        enemyUI.SetHealthUI(enemyHealth);
    }

    [Command]
    public void CmdSetHealth(int health) {
        enemyHealth = health;
    }

    void OnBecameInvisible() {
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
