using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
public class EnemyStatus : NetworkBehaviour {

	[SyncVar]
    [SerializeField]
	private int enemyHealth;

    EnemyUI enemyUI;

    void Awake() {
        enemyUI = GetComponent<EnemyUI>();
        enemyUI.SetHealthUI(enemyHealth);
    }

    [Command]
	public void CmdApplyDamage(int value) {
        enemyHealth -= value;
        Debug.Log("Enemy Health: " + enemyHealth);
        enemyUI.SetHealthUI(enemyHealth);
	}

	public int GetHealth() {
		return enemyHealth;
	}
}
