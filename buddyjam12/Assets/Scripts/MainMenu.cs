using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string firstLevel;
    public GameObject settingsPanel;

    public void Start()
    {
        settingsPanel.SetActive(false);
    }
    
    
    // Start is called before the first frame update
 
    public void StartGame()
    {
        SceneManager.LoadScene(firstLevel);
    }
    public void ViewSetting()
    {
        settingsPanel.SetActive(true);
    }


   
    
 
}
