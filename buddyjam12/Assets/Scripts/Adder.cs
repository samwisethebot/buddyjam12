using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adder : MonoBehaviour
{
    private GameObject mainCam;
    public float camSenX;
    public float camSenY;
    private MoveCamera movCam;
    private PlayerCam pCam;
    
    void Awake()
    {
       // Cursor.lockState = CursorLockMode.Locked; Locking the cursor bugs the seetings UI needs revision
        SetCam();
    }

    
    void Update()
    {
        
    }

    void SetCam() //Adds to the camera the movement scripts...
    {
        mainCam = GameObject.Find("Main Camera"); //Camera.main works too
        mainCam.AddComponent<MoveCamera>();
        mainCam.AddComponent<PlayerCam>();
        movCam = mainCam.GetComponent<MoveCamera>();
        pCam = mainCam.GetComponent<PlayerCam>();

        movCam.cameraPosition = this.transform; //...And the settings
        pCam.orientation = this.transform;
        pCam.sensX = camSenX;
        pCam.sensY = camSenY;
    }
}
