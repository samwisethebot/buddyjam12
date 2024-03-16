using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class PanelScript : MonoBehaviour
{
    [SerializeField] private bool shouldStop;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject cam;
    [SerializeField] private GameObject cursor;
    public GameObject panelValid;
    public GameObject panelInvalid;
    public bool showPanelValid;
    public bool showPanelInvalid;
    public bool isShowing;
    public string winningLevel;
    public string losingLevel;
    


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        cam = GameObject.Find("Main Camera");
        cursor = GameObject.Find("Cursor");
        
    }

    void Update()
    {
        if (showPanelInvalid == false)
        
        {
            panelInvalid.SetActive(false);
            if(showPanelValid == false)
            {
             ActivatePlayer();
             panelValid.SetActive(false);
            }
            else if(showPanelValid)
            {
             StopPlayer();
             panelValid.SetActive(true);
             }
        }

        else if (showPanelValid == false)
        {
            if(showPanelInvalid == false)
            {
             ActivatePlayer();
             panelInvalid.SetActive(false);
            }
            else if(showPanelInvalid)
            {
             StopPlayer();
             panelInvalid.SetActive(true);
             }
        }

        

    }


    public void StopPlayer()
    {
        player.SetActive(false);
        cam.GetComponent<PlayerCam>().enabled = false;
        cam.GetComponent<MoveCamera>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        cursor.SetActive(false);
    }

    public void ActivatePlayer()
    {
       player.SetActive(true);
       cam.GetComponent<PlayerCam>().enabled = true;
       cam.GetComponent<MoveCamera>().enabled = true;
       Cursor.lockState = CursorLockMode.Locked;
       cursor.SetActive(true);
    }

    public void YesValidItem()
    {
        SceneManager.LoadScene(winningLevel);
    }
    public void YesInvalidItem()
    {
        SceneManager.LoadScene(losingLevel);
    }
    public void No()
    {
        showPanelInvalid = false;
        showPanelValid = false;
    }


}
