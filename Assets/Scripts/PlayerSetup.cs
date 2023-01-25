using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetup : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    [SerializeField] GameObject playerCamera;
    void Start()
    {
        if (photonView.IsMine)
        {
            transform.GetComponent<MovmentController>().enabled = true;
            playerCamera.GetComponent<Camera>().enabled = true;
        }
        else
        {
            transform.GetComponent<MovmentController>().enabled = false;
            playerCamera.GetComponent<Camera>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
