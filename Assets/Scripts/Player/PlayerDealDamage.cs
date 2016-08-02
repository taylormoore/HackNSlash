using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PlayerDealDamage : NetworkBehaviour {

	[Command]
	public void CmdDealDamage(EnemyAndDamageHolder enemyAndDamage) {
		enemyAndDamage.enemy.SendMessage("ApplyDamage", enemyAndDamage.damage);
	}
}
