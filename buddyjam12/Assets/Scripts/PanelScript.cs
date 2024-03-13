using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelScript : MonoBehaviour
{
    public string winningLevel;
    public string losingLevel;
    public GameObject panelScreen1;
    public GameObject panelScreen2;

    // Start is called before the first frame update
    void Start()
    {
        
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
        panelScreen1.SetActive(false);
        panelScreen2.SetActive(false);
    }

}
