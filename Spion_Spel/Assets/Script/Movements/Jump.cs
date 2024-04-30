using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float jumpSpeed = 0;

    public Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space) && rb.velocity.y == 0)
        {
            rb.AddForce(Vector3.up * jumpSpeed); 
        }
    }
}
