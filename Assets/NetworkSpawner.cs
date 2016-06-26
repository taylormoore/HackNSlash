using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class NetworkSpawner : NetworkBehaviour {

	[Command]
    public void CmdShootProjectile(Object[] args) {
        GameObject thisProjectile = (GameObject) args[0];
        Transform location = (Transform) args[1];
        Instantiate(thisProjectile, location.position, location.rotation);
        NetworkServer.Spawn(thisProjectile);
        Destroy(thisProjectile, 3f);
    }
}
