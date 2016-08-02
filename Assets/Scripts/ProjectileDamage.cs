using UnityEngine;
using System.Collections;

public class ProjectileDamage : MonoBehaviour {

    int projectileDamage = 0;

	void OnTriggerEnter2D(Collider2D otherObject) {
		if (otherObject.gameObject.tag == "Enemy") {
			if (projectileDamage > 0) {
				DamageRelay relay = new DamageRelay(otherObject.gameObject, projectileDamage);
				PlayerReference.GetHost().SendMessage("CmdDealDamage", relay);
			}
			Destroy(gameObject);
		}
	}

    public void SetDamage(int damage)
    {
		projectileDamage = damage;
    }
}
