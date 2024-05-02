using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDoor : Doors
{
    public bool end;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        end = false;
    }

    // Update is called once per frame
    public override void Update()
    {
        if(Vector3.Distance(player.transform.position, transform.position) < 3f && Input.GetKeyDown(KeyCode.E) && end)
        {
            if (right) animator.SetTrigger("Right");
            if (left) animator.SetTrigger("Left");
        }
    }
}
