using UnityEngine;
using System.Collections;

public class ProjectileDamage : MonoBehaviour {

	[SerializeField]
	float projectileDamage;

	void OnTriggerEnter2D(Collider2D otherObject) {
		if (otherObject.gameObject.tag == "Enemy") {
			otherObject.SendMessage("CmdApplyDamage", projectileDamage);
			Destroy(gameObject);
		}
	}
}
