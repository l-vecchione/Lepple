using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonRPC : MonoBehaviourPunCallbacks
{
    public void LeaveRoom()
    {
        SceneManager.LoadScene("MainMenu");
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.Disconnect();
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        SceneManager.LoadScene("MainMenu");
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.Disconnect();
    }
}
