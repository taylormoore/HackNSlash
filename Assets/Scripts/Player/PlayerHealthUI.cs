using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour {

	[SerializeField]
	Text healthText;

	public void SetHealthUI(int health) {
		healthText.text = health.ToString();
	}
}
