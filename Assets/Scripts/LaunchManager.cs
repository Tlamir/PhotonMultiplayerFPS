using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class LaunchManager : MonoBehaviourPunCallbacks
{
    public override void OnConnectedToMaster()
    {
        Debug.Log(PhotonNetwork.NickName+" Connected to Photon Server");
    }
    public void ConnectToPhotonServer()
    {
        if (!PhotonNetwork.IsConnected)
            PhotonNetwork.ConnectUsingSettings();
    }
}
