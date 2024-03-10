using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OpenDrawer : MonoBehaviour
{
    public bool isOpen;
    public float openPosition = 0.6f;
    public float drawerTime = .5f;
    float closedPosition;

    private void Start()
    {
        closedPosition = this.gameObject.transform.localPosition.z;
    }

    //this should be triggered from interaction script
    public void drawerInteraction() 
    {
        if (isOpen)
        {
            //sound here maybe
            this.transform.DOLocalMoveZ(closedPosition, drawerTime);
            isOpen = false;

        }
        else
        {
            this.transform.DOLocalMoveZ(openPosition, drawerTime);
            isOpen = true;
        }
    }

}
