﻿using UnityEngine;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour {

    [SerializeField]
    Text healthText;

    public void SetHealthUI(int health) {
        healthText.text = health.ToString();
    }
}
