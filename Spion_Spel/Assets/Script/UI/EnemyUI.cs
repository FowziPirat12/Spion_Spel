using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyUI : MonoBehaviour
{
    public float EnemyHealth;
    public NavMeshAgent Enemy;
    public Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        EnemyHealth = 100;

    }

    // Update is called once per frame
    void Update()
    {
        Enemy.SetDestination(Player.position);

    }

     private void OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            EnemyHealth -= 1;
            
            if (EnemyHealth <= 0)
            {
                Destroy(gameObject);
            }
        }    
       
    }
}