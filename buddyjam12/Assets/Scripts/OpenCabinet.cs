using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCabinet : MonoBehaviour
{ 
    public bool isOpen;
    public float openPosition = 90f;
    public float cabinetTime = .5f;
    float closedPosition;

    // Start is called before the first frame update
    void Start()
    {
        closedPosition = this.gameObject.transform.localRotation.y;
        
    }

    public void cabinetInteraction()
    {
        if (isOpen)
        {
            //sound here maybe?
            Vector3 closedVector = new Vector3(0, closedPosition, 0);
            this.transform.DOLocalRotate(closedVector, cabinetTime);
            isOpen = false;
        }

        else
        {
            Vector3 openVector = new Vector3(0, openPosition, 0);
            this.transform.DOLocalRotate(openVector, cabinetTime);
            isOpen = true;

        }
    }

}
