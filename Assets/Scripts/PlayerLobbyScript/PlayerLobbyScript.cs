using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using Random = System.Random;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class PlayerLobbyScript : MonoBehaviourPunCallbacks
{
    public GameObject pulsante, testo;
    public AudioSource carta;
    private void Awake()
    {
        PhotonNetwork.NickName = PlayerPrefs.GetString("NomeUtente");
        
        pulsante.SetActive(false);
        testo.GetComponent<TextMeshProUGUI>().text="Sono richiesti 4 giocatori. \n" +
                                                   "Il numero di giocatori attuale è: " + PhotonNetwork.CurrentRoom.PlayerCount;
        
        if(!PlayerPrefs.HasKey("volume"))
        {
            PlayerPrefs.SetFloat("volume", 1);
        }

        carta.volume = PlayerPrefs.GetFloat("volume");
        carta.Play();
    }

    public override void OnPlayerEnteredRoom(Player other)
    {
        Debug.LogFormat("OnPlayerEnteredRoom() {0}", other.NickName); // not seen if you're the player connecting

        bool nomiUguali=false;
        int temp=0; 
        Player[] players = PhotonNetwork.PlayerList;
            
        foreach (Player player in players)
        {
            foreach (Player player2 in players)
            {
                if (player.NickName.Equals(player2.NickName))
                    temp++;
            }
        }
            
        if (temp > 4) nomiUguali = true;
        
        if (PhotonNetwork.IsMasterClient)
        {
            Debug.LogFormat("OnPlayerEnteredRoom IsMasterClient {0}", PhotonNetwork.IsMasterClient); // called before OnPlayerLeftRoom

            if (players.Length == 4 && !nomiUguali)
            {
                pulsante.SetActive(true);
            }
        }

        if (nomiUguali)
        {
            testo.GetComponent<TextMeshProUGUI>().text="Sono richiesti 4 giocatori. \n" +
                                                       "Il numero di giocatori attuale è: " + PhotonNetwork.CurrentRoom.PlayerCount +
                                                       ". Ci sono due o più giocatori con lo stesso nome: esso deve essere univoco nella stanza.";
        }
        else
        {
            testo.GetComponent<TextMeshProUGUI>().text="Sono richiesti 4 giocatori. \n" +
                                                   "Il numero di giocatori attuale è: " + PhotonNetwork.CurrentRoom.PlayerCount;
        }
    }

    public override void OnPlayerLeftRoom(Player other)
    {
        Debug.LogFormat("OnPlayerLeftRoom() {0}", other.NickName); // seen when other disconnects

        testo.GetComponent<TextMeshProUGUI>().text="Sono richiesti 4 giocatori. \n" +
                                                   "Il numero di giocatori attuale è: " + PhotonNetwork.CurrentRoom.PlayerCount;
        
        if (PhotonNetwork.CurrentRoom.PlayerCount < 4)
            pulsante.SetActive(false);

        if (other.IsMasterClient)
        {
            PhotonNetwork.LeaveRoom();
            PhotonNetwork.Disconnect();
            PhotonNetwork.LoadLevel("MainMenu");
        }
    }
    
    public void LoadGame()
    {
        
        if (PhotonNetwork.IsMasterClient)
        {
            Random random = new Random();
            int num = random.Next(0, 5);
            
            Debug.Log(num);

            Hashtable properties = PhotonNetwork.CurrentRoom.CustomProperties;
            properties.Add("livello", num);
            PhotonNetwork.CurrentRoom.SetCustomProperties(properties);
            PhotonNetwork.LoadLevel("NewGame");
        }
        
        
    }
}
