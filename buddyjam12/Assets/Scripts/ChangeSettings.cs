using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSettings : MonoBehaviour
{
    

    [Header("ChangeSensitivity")]
    [SerializeField] private PlayerCam camSen;
    [SerializeField] private float newSenX;
    [SerializeField] private float newSenY;
    [SerializeField] private InputFieldGrabber inputFieldX;
    [SerializeField] private InputFieldGrabber inputFieldY;

    public void SetChanges()
    {
        camSen.sensX = inputFieldX.inputParsedAsFloat;
        camSen.sensY = inputFieldY.inputParsedAsFloat;
    }
    void Start()
    {
        camSen = GameObject.Find("Main Camera").GetComponent<PlayerCam>();
    }

    
    
}
