using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class LaunchManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject EnterGamePanel;
    [SerializeField] private GameObject ConnectionStatusPanel;
    [SerializeField] private GameObject LobbyPanel;

    private void Start()
    {
        EnterGamePanel.SetActive(true);
        ConnectionStatusPanel.SetActive(false);
        LobbyPanel.SetActive(false);
    }
    public override void OnConnectedToMaster()
    {
        ConnectionStatusPanel.SetActive(false);
        Debug.Log(PhotonNetwork.NickName+" Connected to Photon Server");
        LobbyPanel.SetActive(true);
        
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
