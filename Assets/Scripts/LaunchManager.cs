using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System;
using Photon.Realtime;
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
    #region PhotonCallbacks
    public override void OnConnectedToMaster()
    {
        ConnectionStatusPanel.SetActive(false);
        Debug.Log(PhotonNetwork.NickName+" Connected to Photon Server");
        LobbyPanel.SetActive(true);
    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        base.OnJoinRandomFailed(returnCode, message);
        Debug.Log(message);
        CreateAndJoinRoom();
    }
    public override void OnJoinedRoom()
    {
        Debug.Log(PhotonNetwork.NickName + " joined to room : " + PhotonNetwork.CurrentRoom.Name);
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log(newPlayer.NickName + " joined to room:  " + PhotonNetwork.CurrentRoom.Name);
    }
    #endregion
    private void CreateAndJoinRoom()
    {
        string randomRoomName = "Room " + UnityEngine.Random.Range(0, 1000);
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.IsOpen = true;
        roomOptions.IsVisible = true;
        roomOptions.MaxPlayers = 20;

        PhotonNetwork.CreateRoom(randomRoomName,roomOptions);
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
    public void JoinRandomRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }
}
