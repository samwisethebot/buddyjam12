using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShowRequirements : MonoBehaviour
{
    public GameObject requirements;
    public bool isShowing;
    public float showingPosition;
    public float showingTime = .5f;
    float hiddenPos;

    // Start is called before the first frame update
    void Start()
    {
        hiddenPos = requirements.transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) 
        {
            if (isShowing)
            {
                requirements.transform.DOLocalMoveY(hiddenPos, showingTime);
                isShowing = false;
            }

            else
            {
                requirements.transform.DOLocalMoveY(showingPosition, showingTime);
                isShowing = true;
            }
        }


    }
}
