using Rewired;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerBasicAttack : NetworkBehaviour {
    public GameObject projectile;
    public GameObject thisProjectile;
    float attackCooldown = .4f;
    float lastAttack = 0f;
    PlayerBasicAttack thisScript;

    private Player player;
    private bool attackRight, attackLeft, attackUp, attackDown = false;

    void Start() {
        player = ReInput.players.GetPlayer(0);
        thisScript = gameObject.GetComponent<PlayerBasicAttack>();
    }

    void Update() {
        DetectAttackInput();

        if (Time.time > lastAttack + attackCooldown) {
            if (attackLeft) {
                //((GameObject)Instantiate(projectile, transform.position, transform.rotation)).SendMessage("UpdateDirection", 1);
                CmdShootProjectile(1, gameObject);
                lastAttack = Time.time;
            }
            else if (attackRight) {
                //((GameObject)Instantiate(projectile, transform.position, transform.rotation)).SendMessage("UpdateDirection", 1);
                CmdShootProjectile(2, gameObject);
                lastAttack = Time.time;
            }
            else if (attackUp) {
                //((GameObject)Instantiate(projectile, transform.position, transform.rotation)).SendMessage("UpdateDirection", 1);
                CmdShootProjectile(3, gameObject);
                lastAttack = Time.time;
            }
            else if (attackDown) {
                
                //((GameObject)Instantiate(projectile, transform.position, transform.rotation)).SendMessage("UpdateDirection", 1);
                CmdShootProjectile(4, gameObject);
                lastAttack = Time.time;
            }
        }
    }

    public void SetProjectileToDestroy(GameObject proj)
    {
        thisProjectile = proj;
    }

    [Command]
    public void CmdShootProjectile(int direction, GameObject spawner) {
        RpcDestroyProjectile(spawner.transform.position, direction, spawner);
        //thisProjectile = (GameObject) Instantiate(projectile, transform.position, transform.rotation);
        //thisProjectile.SendMessage("UpdateDirection", direction);
        //Destroy(thisProjectile, 3f);
        //NetworkServer.Spawn(thisProjectile);
    }

    [ClientRpc]
    public void RpcDestroyProjectile(Vector2 position, int direction, GameObject spawner)
    {
        if (gameObject == spawner)
            ((GameObject)Instantiate(projectile, transform.position, Quaternion.identity)).SendMessage("UpdateDirection", direction);
        else
            ((GameObject)Instantiate(projectile, spawner.transform.position, Quaternion.identity)).SendMessage("UpdateDirection", direction);
    }

    void DetectAttackInput() {
        attackRight = player.GetAxisRaw("AttackHorizontal") > 0;
        attackLeft = player.GetAxisRaw("AttackHorizontal") < 0;
        attackUp = player.GetAxisRaw("AttackVertical") > 0;
        attackDown = player.GetAxisRaw("AttackVertical") < 0;
    }
}
