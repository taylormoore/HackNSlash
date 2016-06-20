using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour {

	[SerializeField]
	Text healthText;

	EnemyStatus enemyStatus;

	void Awake() {
		enemyStatus = GetComponent<EnemyStatus>();
		SetHealthUI();
	}

	public void SetHealthUI() {
		healthText.text = enemyStatus.GetHealth().ToString();
	}
}
