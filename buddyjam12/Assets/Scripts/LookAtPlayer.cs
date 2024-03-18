using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class LookAtPlayer : MonoBehaviour
{
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {

        transform.LookAt(player.transform.position);

    }
}
