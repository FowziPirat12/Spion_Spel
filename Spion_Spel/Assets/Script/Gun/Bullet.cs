using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Entity entity;
    public Rigidbody myRb;
    public float speed;
    public float bulletDmg;
    public float maxDistance;
    // Start is called before the first frame update
    void Start()
    {
        myRb.AddForce(transform.forward * speed);
        Destroy(this.gameObject, maxDistance);
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            other.GetComponent<Entity>().TakeDamage(bulletDmg);
            Destroy(this.gameObject);
        }
    }
}
