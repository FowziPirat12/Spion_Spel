using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public float hp;
    // Start is called before the first frame update
    void Start()
    {
        hp = 20;
    }

    // Update is called once per frame
    void Update()
    {
        if(hp <= 0){
            Destroy(this.gameObject);
        }
    }
    public void TakeDamage(float dmg)
    {
        hp -= dmg;
    }

    
}
