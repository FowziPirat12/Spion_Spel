using UnityEngine;

public class Doors : MonoBehaviour
{
    public GameObject player;
    public Animator animator;
    public bool right, left;
    public virtual void Start()
    {
        player = GameObject.FindWithTag("Player");
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if(Vector3.Distance(player.transform.position, transform.position) < 3f && Input.GetKeyDown(KeyCode.E))
        {
            if (right) animator.SetTrigger("Right");
            if (left) animator.SetTrigger("Left");
        }
    }
}
