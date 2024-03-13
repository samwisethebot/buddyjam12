using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShowUI : MonoBehaviour
{
    public GameObject toShow;

    [SerializeField] private bool shouldStop;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject cam;
    [SerializeField] private GameObject cursor;

    public bool isShowing;
    public float showingPosition;
    public float showingTime = .5f;
    float hiddenPos;

    public string input;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        cam = GameObject.Find("Main Camera");
        cursor = GameObject.Find("Cursor");
        toShow = this.gameObject;
        hiddenPos = toShow.transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(input)) 
        {
            
            if (isShowing)
            {
                if (shouldStop)
                {
                    ActivatePlayer();
                }

                toShow.transform.DOLocalMoveY(hiddenPos, showingTime);
                isShowing = false;
            }

            else
            {
                if (shouldStop)
                {
                    StopPlayer();
                }

                toShow.transform.DOLocalMoveY(showingPosition, showingTime);
                isShowing = true;
            }
        }

    }

    private void StopPlayer()
    {
        player.SetActive(false);
        cam.GetComponent<PlayerCam>().enabled = false;
        cam.GetComponent<MoveCamera>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        cursor.SetActive(false);
    }

    private void ActivatePlayer()
    {
        player.SetActive(true);
        cam.GetComponent<PlayerCam>().enabled = true;
        cam.GetComponent<MoveCamera>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        cursor.SetActive(true);
    }
}
