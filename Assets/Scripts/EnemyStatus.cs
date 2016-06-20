using UnityEngine;
using System.Collections;

public class EnemyStatus : MonoBehaviour {

	[SerializeField]
	private int enemyHealth;

	public void ApplyDamage(int value) {
		enemyHealth -= value;
	}

	public int GetHealth() {
		return enemyHealth;
	}
}
