using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using TMPro;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class ScopriCarteScript : MonoBehaviourPunCallbacks
{
    public GameObject text, text2, text3, text4;
    public GameObject charName, charName2, charName3, charName4;
    public GameObject riprova, continuac;
    public GameObject openChat, ScopriCarte;
    public bool open;
    public AudioSource carta;

    public override void OnEnable()
    {
        open = false;
        openChat.SetActive(false);
        ScopriCarte.SetActive(true);
        riprova.SetActive(false);
        continuac.SetActive(false);
        
        PlayerPrefs.SetString("livello", ""+PhotonNetwork.CurrentRoom.CustomProperties["livello"]);

        int rip = PlayerPrefs.GetInt("Ripetuto");
        int round = PlayerPrefs.GetInt("Round");

        Hashtable properties = PhotonNetwork.CurrentRoom.CustomProperties;
        Player[] player = PhotonNetwork.PlayerList;

        text.GetComponent<TextMeshProUGUI>().text = (string)properties[player[0].NickName+rip+round];
        text2.GetComponent<TextMeshProUGUI>().text = (string)properties[player[1].NickName+rip+round];
        text3.GetComponent<TextMeshProUGUI>().text = (string) properties[player[2].NickName+rip+round];
        text4.GetComponent<TextMeshProUGUI>().text = (string) properties[player[3].NickName+rip+round];


        charName.GetComponent<TextMeshProUGUI>().text = player[0].NickName;
        charName2.GetComponent<TextMeshProUGUI>().text = player[1].NickName;
        charName3.GetComponent<TextMeshProUGUI>().text = player[2].NickName;
        charName4.GetComponent<TextMeshProUGUI>().text = player[3].NickName;

        calcoloPunteggio();
        
        if(!PlayerPrefs.HasKey("volume"))
        {
            PlayerPrefs.SetFloat("volume", 1);
        }

        carta.volume = PlayerPrefs.GetFloat("volume");
        carta.Play();
        
        base.OnEnable();
    }

    //Metodo del calcolo del punteggio:
    //  100 punti per round.
    //    Per ogni round oltre il primo, -15 punti (max 15*3 punti decurtati).
    //    Se la stima è incorretta: 0 punti.
    public void calcoloPunteggio()
    {
        int punteggio, ripetuto = 0, temp=0, round;
        string reale = PlayerPrefs.GetString("StimaReale");

        if (PlayerPrefs.HasKey("Ripetuto"))
        {
            ripetuto = PlayerPrefs.GetInt("Ripetuto");
            temp = ripetuto;
            if (temp > 3) temp = 3;
        }

        round = PlayerPrefs.GetInt("Round");

        //check se tutti i giocatori hanno la stessa carta
        Hashtable properties = PhotonNetwork.CurrentRoom.CustomProperties;
        //Hashtable newprops = new Hashtable();
        Player[] player = PhotonNetwork.PlayerList;
        
        
        if (properties[player[0].NickName+ripetuto+round].Equals(properties[player[1].NickName+ripetuto+round]) &&
            properties[player[0].NickName+ripetuto+round].Equals(properties[player[2].NickName+ripetuto+round]) &&
            properties[player[0].NickName+ripetuto+round].Equals(properties[player[3].NickName+ripetuto+round]))//equals per 4 giocatori
        {
            if (PhotonNetwork.IsMasterClient)
            {
                continuac.SetActive(true);
                riprova.SetActive(false);
            }

            //check se il valore è giusto
            if (String.Equals(reale, properties[PhotonNetwork.LocalPlayer.NickName+ripetuto+round]))
            {
                punteggio = 100 - temp * 15;
            }
            else
            {
                punteggio = 0;
            }

            PlayerPrefs.SetInt("Risultato", punteggio);
            PlayerPrefs.DeleteKey("Ripetuto");
            
            if (round == 1)
            {
                round++;
                PlayerPrefs.SetInt("Round", round);
                PlayerPrefs.SetInt("Risultato1", PlayerPrefs.GetInt("Risultato"));
            }
            else if (round == 2)
            {
                round++;
                PlayerPrefs.SetInt("Round", round);
                PlayerPrefs.SetInt("Risultato2", PlayerPrefs.GetInt("Risultato"));
            }
            else if(round==3)
            {
                round++;
                PlayerPrefs.SetInt("Round", round);
            }
        }
        else
        {
            ripetuto++;
            PlayerPrefs.SetInt("Ripetuto", ripetuto);
            
            //newprops["livello"] = properties["livello"];
            /*if (!PhotonNetwork.IsMasterClient) return;

            foreach (Player play in player)
            {
                PhotonNetwork.CurrentRoom.CustomProperties.Remove("" + play.NickName);
                PhotonNetwork.CurrentRoom.CustomProperties.Add(""+play.NickName, "-1");
            }
            
            //PhotonNetwork.CurrentRoom.SetCustomProperties(newprops);
            */
            
            if (PhotonNetwork.IsMasterClient)
            {
                riprova.SetActive(true);
                continuac.SetActive(false);
            }
        }

    }

    public void PhotonLoadRiprova()
    {
        if (PhotonNetwork.IsMasterClient)
            PhotonNetwork.LoadLevel("NewGame");
    }

    public void PhotonLoadContinua()
    {
        int round = PlayerPrefs.GetInt("Round")-1;
        if (round == 1)
        {
            if (PhotonNetwork.IsMasterClient)
                PhotonNetwork.LoadLevel("NewGame");
        }
        else if (round == 2)
        {
            if (PhotonNetwork.IsMasterClient)
                PhotonNetwork.LoadLevel("NewGame");
        }
        else if (round == 3)
        {
            if (PhotonNetwork.IsMasterClient)
                PhotonNetwork.LoadLevel("Risultati");
        }
    }

    public void OpenChat()
    {
        if (open)
        {
            open = false;
            openChat.SetActive(false);
        }

        else
        {
            open = true;
            openChat.SetActive(true);
        }
    }
}