using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    //defining camera movement

    //mouse sensitivity
    public float sensX;
    public float sensY;

    public Transform orientation; 

    //camera rotation
    float xRotation;
    float yRotation;

    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked; Locking the cursor bugs the settings UI needs revision
    }

    private void Update()
    {
        //get mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //rotate cam and orientation
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);


    }


}
