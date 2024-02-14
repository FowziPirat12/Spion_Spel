using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1f;
    private new Camera camera;
    
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            //transform.position += new Vector3(0,0, speed * Time.deltaTime);
            transform.position += transform.forward * Time.deltaTime * speed;

        }

        if (Input.GetKey(KeyCode.S))
        {
            //transform.position += new Vector3(0,0, -speed * Time.deltaTime);
            transform.position += -transform.forward * Time.deltaTime * speed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            //transform.position += new Vector3(Time.deltaTime * speed,0,0);
            transform.position += transform.right * Time.deltaTime * speed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            //transform.position += new Vector3(Time.deltaTime * -speed,0,0);
            transform.position += -transform.right * Time.deltaTime * speed;
        }
    }

}