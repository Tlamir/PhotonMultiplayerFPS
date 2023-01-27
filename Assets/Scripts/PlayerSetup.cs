using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerSetup : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    [SerializeField] GameObject playerCamera;
    [SerializeField] TextMeshProUGUI playerNameText;
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
            playerCamera.GetComponent<AudioListener>().enabled = false;
        }
        SetPlayerUI();
    }

    void SetPlayerUI()
    {
        if (playerNameText!=null)
        {
            playerNameText.text = photonView.Owner.NickName;
        }
    }
}
