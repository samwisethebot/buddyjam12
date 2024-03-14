using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform cameraPosition;
    public float cameraYOffset = 0.5f;


    private void Update()
    {
       transform.position = cameraPosition.position + new Vector3(0f, cameraYOffset,0f);
    }
}
