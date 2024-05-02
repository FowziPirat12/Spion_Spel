
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public RigidMovment playerMovment;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == playerMovment.gameObject)
        return;

        playerMovment.SetGrounded(true);
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == playerMovment.gameObject)
        return;

        playerMovment.SetGrounded(false);
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject == playerMovment.gameObject)
        return;

        playerMovment.SetGrounded(true);
    }
}
