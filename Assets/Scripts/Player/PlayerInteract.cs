using UnityEngine;
using System.Collections.Generic;
using Rewired;

public class PlayerInteract : MonoBehaviour {

	Player player;
	HashSet<GameObject> interactablesInRage;

	void Start() {
		interactablesInRage = new HashSet<GameObject>();
		player = ReInput.players.GetPlayer(0);
	}

	void Update() {
		if (player.GetButtonDown("Interact")) {
			Interact(utils.FindNearestObject(gameObject, interactablesInRage));
		}
	}

	public void Interact(GameObject interactable) {
		interactable.SendMessage("Interact", gameObject);
	}

	public void RemoveFromList(GameObject obj) {
		interactablesInRage.Remove(obj);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Interactable" && other.gameObject != null) {
			interactablesInRage.Add(other.gameObject);
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.tag == "Interactable" && other.gameObject != null) {
			interactablesInRage.Remove(other.gameObject);
		}
	}
}
