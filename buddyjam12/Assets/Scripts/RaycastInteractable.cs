using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastInteractable : MonoBehaviour
{
    public float force;
    public Camera mainCam;
    public float distance;
    public LayerMask mask;
    void Start()
    {
        mainCam = Camera.main;
        mask = LayerMask.GetMask("interactRaycast");

    }
        void Update()
        {

          if (Input.GetMouseButtonDown(0))
          {
             showRay();
          }

        }

    void showRay()
    {
        //Shows visually the ray in the scene, but does nothing
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = distance;
        mousePos = mainCam.ScreenToWorldPoint(mousePos);
        Debug.DrawRay(transform.position, mousePos - transform.position, Color.blue);

        //Creates the ray in the scene and detects a colission + adds force to it

        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit objHit;

        if (Physics.Raycast(ray, out objHit, distance, mask)) //Ray, colission obj, distance of ray, identify by mask
        {
            Debug.Log(objHit.transform.name);

            if (objHit.rigidbody) 
            {
                objHit.rigidbody.AddForce(0, force * 100, 0);
            }
            
        }
    }
    
}
