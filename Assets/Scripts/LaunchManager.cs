using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class LaunchManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject EnterGamePanel;
    [SerializeField] private GameObject ConnectionStatusPanel;

    private void Start()
    {
        EnterGamePanel.SetActive(true);
        ConnectionStatusPanel.SetActive(false);
    }
    public override void OnConnectedToMaster()
    {
        Debug.Log(PhotonNetwork.NickName+" Connected to Photon Server");
    }
    public void ConnectToPhotonServer()
    {
        if (!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.ConnectUsingSettings();
            ConnectionStatusPanel.SetActive(true);
            EnterGamePanel.SetActive(false);
        }
            

    }
}
