using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1f;
   
    private new Camera camera;

    private Vector3 crouchScale = new Vector3(1, 0.5f, 1); 
    private Vector3 playerscale = new Vector3(1, 1f, 1);
    
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) )
        {
            //transform.position += new Vector3(0,0, speed * Time.deltaTime);
            transform.position += transform.forward * Time.deltaTime * speed;
        }

        if (Input.GetKey(KeyCode.S))
        {
            //transform.position += new Vector3(0,0, -speed * Time.deltaTime);
            transform.position += -transform.forward * Time.deltaTime * (speed * 0.5f);
        }

        if (Input.GetKey(KeyCode.D))
        {
            //transform.position += new Vector3(Time.deltaTime * speed,0,0);
            transform.position += transform.right * Time.deltaTime * (speed * 0.7f);
        }

        if (Input.GetKey(KeyCode.A))
        {
            //transform.position += new Vector3(Time.deltaTime * -speed,0,0);
            transform.position += -transform.right * Time.deltaTime * (speed * 0.7f);
        }
        
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed *= 1.5f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed /= 1.5f;
        }

         if (Input.GetKeyDown(KeyCode.LeftControl)) 
        {
            transform.localScale = crouchScale;
            transform.position = new Vector3(transform.position.x, transform.position.y -0.5f, transform.position.z);
            speed *= 0.5f;
        }

        if (Input.GetKeyUp(KeyCode.LeftControl)) 
        {
            transform.localScale = playerscale;
            transform.position = new Vector3(transform.position.x, transform.position.y +0.5f, transform.position.z);
            speed *= 2f;
        }
    }

}