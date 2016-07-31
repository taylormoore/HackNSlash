using UnityEngine;
using System.Collections.Generic;

public class EnemyItemDrop : MonoBehaviour {

	[SerializeField]
	List<GameObject> droppableItems;

	[SerializeField]
	float itemDropChance;

	float roll;

	void Start() {
		roll = Random.Range(0f, 100f);
	}

	public void DropItem() {
		if (roll > 100 - itemDropChance) {
			Instantiate(droppableItems[(int)roll % droppableItems.Count], transform.position,
				Quaternion.identity);
		}
	}
}
