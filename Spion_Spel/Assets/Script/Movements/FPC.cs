using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPC : MonoBehaviour
{
    public Transform player;
    public float mouseSensitvity = 2f;
    float cameraVerticalRotation = 0f;
    bool on;

   
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false; 
        Cursor.lockState = CursorLockMode.Locked;
        on = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C)) on = !on;
        if(on)
        {
            float inputX = Input.GetAxis("Mouse X") * mouseSensitvity;
            float inputY = Input.GetAxis("Mouse Y") * mouseSensitvity;

            cameraVerticalRotation -= inputY;
            cameraVerticalRotation= Mathf.Clamp(cameraVerticalRotation, -90f, 90f);
            transform.localEulerAngles = Vector3.right * cameraVerticalRotation;

            player.Rotate(Vector3.up * inputX);
        }

    }
}
