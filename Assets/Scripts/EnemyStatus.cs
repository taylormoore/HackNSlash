using UnityEngine;
using System.Collections;

public class EnemyStatus : MonoBehaviour {

	[SerializeField]
	private int enemyHealth;

	GameObject player;

	void FixedUpdate() {
		CheckForPlayers();
	}

	public void ApplyDamage(int value) {
		enemyHealth -= value;
	}

	public int GetHealth() {
		return enemyHealth;
	}

	void CheckForPlayers() {
		if (PlayerReference.PlayersArePresent()) {

		} else {

		}
	}

	void MoveTowardsTarget() {

	}
}
