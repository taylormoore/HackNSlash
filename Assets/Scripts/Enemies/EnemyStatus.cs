using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

[NetworkSettings(channel=1,sendInterval=0.2f)]
public class EnemyStatus : NetworkBehaviour {

	[SyncVar]
    [SerializeField]
	private int enemyHealth;

    float damageCooldown = 2f;
    float lastDamageTaken;

    void Start() {
        lastDamageTaken = Time.time;
    }

	public void CmdApplyDamage(int value) {
        if (Time.time > lastDamageTaken + damageCooldown) {
            lastDamageTaken = Time.time;
            enemyHealth -= value;
            Debug.Log("Enemy Health: " + enemyHealth);
        }
	}

	public int GetHealth() {
		return enemyHealth;
	}
}
