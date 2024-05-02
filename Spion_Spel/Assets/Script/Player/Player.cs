using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float playerHP;
    HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        playerHP = 100;
        healthBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthBar>();
        healthBar.SetMaxHealth(playerHP);
    }

    // Update is called once per frame
    void Update()
    {
        if(playerHP <= 0) SceneManager.LoadScene(1);
    }
    public void TakeDamage(float damage)
    {
        playerHP-=damage;
        healthBar.SetHealth(playerHP);
    }
}
