using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public Transform player;
    public EndDoor endDoor;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        endDoor = GameObject.FindGameObjectWithTag("EndDoor").GetComponent<EndDoor>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(player.position, transform.position) <= 1.5f && Input.GetKeyDown(KeyCode.E)){
            endDoor.end = true;
            Destroy(gameObject);
        }	
    }
}
