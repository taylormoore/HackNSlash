using UnityEngine;

public class DamageRelay {

	public GameObject receiver;
	public float damage;

	public DamageRelay(GameObject receiver, float damage) {
		this.receiver = receiver;
		this.damage = damage;
	}
}
