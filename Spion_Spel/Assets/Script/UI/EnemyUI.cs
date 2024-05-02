using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.WSA;

public class EnemyUI : MonoBehaviour
{
    public bool chase;
    public NavMeshAgent Enemy;
    public Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        Enemy = this.gameObject.GetComponent<NavMeshAgent>();
        chase = true;
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (chase)Enemy.SetDestination(Player.position);
    }
}
