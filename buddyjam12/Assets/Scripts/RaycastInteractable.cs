using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RaycastInteractable : MonoBehaviour
{
    public float force;
    public Camera mainCam;
    public float distance;
    public LayerMask interactMask;
    public LayerMask validMask;
    public LayerMask itemsMask;
    public string winningLevel;
    public string losingLevel;



    void Start()
    {
        mainCam = Camera.main;
        interactMask = LayerMask.GetMask("interactRaycast");
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
        //Shows VISUALLY the ray trajectory in the scene
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = distance;
        mousePos = mainCam.ScreenToWorldPoint(mousePos);
        Debug.DrawRay(transform.position, mousePos - transform.position, Color.blue);

        //Creates the ray in the scene and detects a colission + any action afterwards
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit objHit;

        if (Physics.Raycast(ray, out objHit, distance, interactMask)) //Ray, colission obj, distance of ray, identify by mask
        {
            Debug.Log(objHit.transform.name + " is interactable");
           
            //checks if gameobject has openDrawer script, then plays that interaction
            if (objHit.collider.gameObject.TryGetComponent<OpenDrawer>(out OpenDrawer drawerScript))
            {
                drawerScript.drawerInteraction();
            }

            //checks if gameobject has openCabinet script, then plays that interaction
            if (objHit.collider.gameObject.TryGetComponent<OpenCabinet>(out OpenCabinet cabinetScript))
            {
                cabinetScript.cabinetInteraction();
            }
        }

        //Adding check for the validMask
        else if (Physics.Raycast(ray, out objHit, distance, validMask))
        {                       
            Debug.Log("Clicked on the valid <" + objHit.transform.name + "> item");
            //SceneManager.LoadScene(winningLevel);
           //call bool from PanelScript here
            
        }

        //Adding check for the itemsMask (invalid items)
        else if (Physics.Raycast(ray, out objHit, distance, itemsMask))
        {                             
            Debug.Log("Clicked on the wrong <" + objHit.transform.name + "> item");
            //SceneManager.LoadScene(losingLevel);
            //panelInvalid.SetActive(true);
            //call bool from PanelScript here
            
        }
    }
    
}