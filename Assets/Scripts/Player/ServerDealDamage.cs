using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class ServerDealDamage : NetworkBehaviour {

	[Command]
	public void CmdDealDamage(GameObject receiver) {//GameObject receiver, float damage) {
		receiver.SendMessage("ApplyDamage", 10);
	}
}
