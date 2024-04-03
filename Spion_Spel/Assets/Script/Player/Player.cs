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
        if(Input.GetKeyDown(KeyCode.H) && playerHP + 10 <=100)
        {
            playerHP += 10;
            healthBar.SetHealth(playerHP);
        }
        if(Input.GetKeyDown(KeyCode.J) && playerHP - 10 >=0)
        {
            playerHP -= 10;
            healthBar.SetHealth(playerHP);
        }

    }

    private void OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.tag == "Enemy"){
            playerHP -= 10;
            healthBar.SetHealth(playerHP);
        }    
    }
}
