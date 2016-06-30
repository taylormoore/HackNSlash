﻿using Rewired;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerBasicAttack : NetworkBehaviour {
    public GameObject projectile;
    float attackCooldown = .4f;
    float lastAttack = 0f;

    private Player player;
    private bool attackRight, attackLeft, attackUp, attackDown = false;

    void Start() {
        player = ReInput.players.GetPlayer(0);
    }

    void Update() {
        DetectAttackInput();

        if (Time.time > lastAttack + attackCooldown) {
            if (attackLeft) {
                CmdShootProjectile(1);
                lastAttack = Time.time;
            }
            else if (attackRight) {
                CmdShootProjectile(2);
                lastAttack = Time.time;
            }
            else if (attackUp) {
                CmdShootProjectile(3);
                lastAttack = Time.time;
            }
            else if (attackDown) {
                CmdShootProjectile(4);
                lastAttack = Time.time;
            }
        }
    }

    [Command]
    public void CmdShootProjectile(int direction) {
        GameObject thisProjectile = (GameObject) Instantiate(projectile, transform.position, transform.rotation);
        thisProjectile.SendMessage("UpdateDirection", direction);
        Destroy(thisProjectile, 3f);
        NetworkServer.Spawn(thisProjectile);
    }

    void DetectAttackInput() {
        if (player.GetAxisRaw("AttackHorizontal") > 0) {
            attackRight = true;
        }
        else {
            attackRight = false;
        }

        if (player.GetAxisRaw("AttackHorizontal") < 0) {
            attackLeft = true;
        }
        else {
            attackLeft = false;
        }

        if (player.GetAxisRaw("AttackVertical") > 0) {
            attackUp = true;
        }
        else {
            attackUp = false;
        }

        if (player.GetAxisRaw("AttackVertical") < 0) {
            attackDown = true;
        }
        else {
            attackDown = false;
        }
    }
}
