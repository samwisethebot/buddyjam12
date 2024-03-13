using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastInteractable : MonoBehaviour
{
    public float force;
    public Camera mainCam;
    public float distance;
    public LayerMask mask;
    public LayerMask validMask;
    public LayerMask itemsMask;


    void Start()
    {
        mainCam = Camera.main;
        mask = LayerMask.GetMask("interactRaycast");
        validMask = LayerMask.GetMask("validItemLayer");
        itemsMask = LayerMask.GetMask("itemsLayer");

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

            //checks if gameobject has openDrawer script, then plays that interaction
            else if( objHit.collider.gameObject.TryGetComponent<OpenDrawer>(out OpenDrawer drawerScript))
            {
                drawerScript.drawerInteraction();
            }

            else if (objHit.collider.gameObject.TryGetComponent<OpenCabinet>(out OpenCabinet cabinetScript))
            {
                cabinetScript.cabinetInteraction();
            }
        }
        //adding check for the validMask
        else if (Physics.Raycast(ray, out objHit, distance, validMask))
        {
            Debug.Log(objHit.transform.name);

            if (objHit.rigidbody) 
            {
                objHit.rigidbody.AddForce(0, force * 100, 0);
            }
            
            else
            {
                Debug.Log("Clicked on the valid item");
                //move on to winning scene
            }
        }

        //adding check for all invalid items
        else if (Physics.Raycast(ray, out objHit, distance, itemsMask))
        {
            Debug.Log(objHit.transform.name);

            if (objHit.rigidbody) 
            {
                objHit.rigidbody.AddForce(0, force * 100, 0);
            }
            
            else
            {
                Debug.Log("Clicked on the wrong item");
                //move on to losing scene
            }
        }
    }
    
}