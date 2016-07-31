using UnityEngine;
using System.Collections;

public class ProjectileDamage : MonoBehaviour {

	[SerializeField]
	float projectileDamage;

    bool isReal;

	void OnTriggerEnter2D(Collider2D otherObject) {
		if (otherObject.gameObject.tag == "Enemy") {
			if (isReal) {
				otherObject.SendMessage("ApplyDamage", projectileDamage);
			}
			Destroy(gameObject);
		}
	}

    public void SetReal(bool real)
    {
        isReal = real;
    }

    public bool GetReal()
    {
        return isReal;
    }
}
