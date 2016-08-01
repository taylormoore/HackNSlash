using UnityEngine;

public class Item : MonoBehaviour {

    [SerializeField]
    string itemName;

	public void Interact(GameObject interacter) {
		interacter.SendMessage("AddToInventory", gameObject);
		interacter.SendMessage("RemoveFromList", gameObject);
		Destroy(gameObject);
	}
}
