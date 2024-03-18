using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class MultiplayerInitializationScript : MonoBehaviourPunCallbacks
{
    private byte maxPlayersPerRoom = 4;
    public AudioSource carta;
    
    // <summary>
    // This client's version number. Users are separated from each other by gameVersion (which allows you to make breaking changes).
    // </summary>
    string gameVersion = "1";
    
    void Awake()
    {
        // #Critical
        // this makes sure we can use PhotonNetwork.LoadLevel() on the master client and all clients in the same room sync their level automatically
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.NickName = PlayerPrefs.GetString("NomeUtente");
        
        if(!PlayerPrefs.HasKey("volume"))
        {
            PlayerPrefs.SetFloat("volume", 1);
        }

        carta.volume = PlayerPrefs.GetFloat("volume");
        carta.Play();
    }

    public void ConnectCreate()
    {
        if (PhotonNetwork.IsConnected)
        {
            // #Critical we need at this point to attempt joining a Random Room. If it fails, we'll get notified in OnJoinRandomFailed() and we'll create one.
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            // #Critical, we must first and foremost connect to Photon Online Server.
            PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.GameVersion = gameVersion;
        }
        
    }

    public override void OnConnectedToMaster()
    {
        if(PhotonNetwork.CountOfRooms==0)
            PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = maxPlayersPerRoom, DeleteNullProperties = true});
        else PhotonNetwork.JoinRandomRoom();
    }

    public override void OnCreatedRoom()
    {
        base.OnCreatedRoom();
        SceneManager.LoadScene("PlayerLobby");
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.LogWarningFormat("PUN Basics Tutorial/Launcher: OnDisconnected() was called by PUN with reason {0}", cause);
    }
    
}