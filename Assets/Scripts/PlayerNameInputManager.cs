using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;
using Photon.Pun;

public class PlayerNameInputManager : MonoBehaviour
{
    public void SetPlayerName(string playerName)
    {
        if (string.IsNullOrEmpty(playerName))
        {
            Debug.Log("Player Name is Empty");
            return;
        }
        PhotonNetwork.NickName = playerName;
    }
}
