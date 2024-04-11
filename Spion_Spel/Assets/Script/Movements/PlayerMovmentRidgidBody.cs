using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovmentRidgidBody : MonoBehaviour
{
    // Start is called before the first frame update
    float speed = 10f;
    public Rigidbody player;
    public Vector3 movment;

    void Start()
    {
        player = this.GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        //RidgidMovment(movment);

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(horizontal, 0, vertical);
        
        player.velocity = move * speed;
    }
    
    /*void RidgidMovment(Vector3 direction)
    {
        Vector3 moveDirection = HandleInput();
        player.MovePosition(transform.position + moveDirection);
    }

    Vector3 HandleInput(){
        Vector3 direction = new Vector3();
        if (Input.GetKey(KeyCode.W) )
        {
            //transform.position += new Vector3(0,0, speed * Time.deltaTime);
            direction += transform.forward;
        }

        if (Input.GetKey(KeyCode.S))
        {
            //transform.position += new Vector3(0,0, -speed * Time.deltaTime);
            direction  += -transform.forward ;
        }

        if (Input.GetKey(KeyCode.D))
        {
            //transform.position += new Vector3(Time.deltaTime * speed,0,0);
            direction  += transform.right;
        }

        if (Input.GetKey(KeyCode.A))
        {
            //transform.position += new Vector3(Time.deltaTime * -speed,0,0);
            direction  += -transform.right;
        }

        return direction.normalized * Time.deltaTime * speed;
    }*/

}
