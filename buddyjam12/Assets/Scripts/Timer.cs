using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class Timer : MonoBehaviour
{
    [SerializeField] TMP_Text timerText;
    [SerializeField] float startTime;
    float currentTime;
    bool hasTriggered;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        timerText.text = "Timer: " + Mathf.RoundToInt(currentTime);
        currentTime -= Time.deltaTime;

        if(currentTime<= 0 && !hasTriggered)
        {
            SceneManager.LoadScene("LosingScene");
            hasTriggered = true;
        }
    }
}
