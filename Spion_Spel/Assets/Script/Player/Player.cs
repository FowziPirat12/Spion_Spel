using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        
    }
}
