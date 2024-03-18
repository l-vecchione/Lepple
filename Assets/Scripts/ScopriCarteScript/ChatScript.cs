using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using TMPro;

public class ChatScript : MonoBehaviourPunCallbacks
{
    public GameObject openChat, scopriCarte;
    public GameObject text1, text2, text3, text4, text5;
    public GameObject textChange;
    public AudioSource carta;

    public override void OnEnable()
    {
        aggiorna();
        base.OnEnable();
    }

    public void addMex()
    {
        PlayerPrefs.SetInt("Ach4", 1);
        
        Hashtable properties = PhotonNetwork.CurrentRoom.CustomProperties;

        string temp = textChange.GetComponent<TextMeshProUGUI>().text;

        if (temp.Length > 150)
        {
            return;
        }
        
        textChange.GetComponent<TextMeshProUGUI>().text = "";
        
        text5.GetComponent<TextMeshProUGUI>().text = text4.GetComponent<TextMeshProUGUI>().text;
        text4.GetComponent<TextMeshProUGUI>().text = text3.GetComponent<TextMeshProUGUI>().text;
        text3.GetComponent<TextMeshProUGUI>().text = text2.GetComponent<TextMeshProUGUI>().text;
        text2.GetComponent<TextMeshProUGUI>().text = text1.GetComponent<TextMeshProUGUI>().text;
        text1.GetComponent<TextMeshProUGUI>().text =
            PhotonNetwork.LocalPlayer.NickName + "\n" + temp;

        //properties.Remove("mex5");
        //properties.Remove("mex4");
        //properties.Remove("mex3");
        //properties.Remove("mex2");
        //properties.Remove("mex1");
        
        properties["mex5"]= text5.GetComponent<TextMeshProUGUI>().text;
        properties["mex4"]= text4.GetComponent<TextMeshProUGUI>().text;
        properties["mex3"]= text3.GetComponent<TextMeshProUGUI>().text;
        properties["mex2"]= text2.GetComponent<TextMeshProUGUI>().text;
        properties["mex1"]= text1.GetComponent<TextMeshProUGUI>().text;
        //properties.Add("mex4", text4.GetComponent<TextMeshProUGUI>().text);
        //properties.Add("mex3", text3.GetComponent<TextMeshProUGUI>().text);
        //properties.Add("mex2", text2.GetComponent<TextMeshProUGUI>().text);
        //properties.Add("mex1", text1.GetComponent<TextMeshProUGUI>().text);

        PhotonNetwork.CurrentRoom.SetCustomProperties(properties);
    }

    public void aggiorna()
    {
        Hashtable properties = PhotonNetwork.CurrentRoom.CustomProperties;

        if (properties.ContainsKey("mex1"))
        {
            if (properties.ContainsKey("mex2"))
            {
                if (properties.ContainsKey("mex3"))
                {
                    if (properties.ContainsKey("mex4"))
                    {
                        if (properties.ContainsKey("mex5"))
                        {
                            text5.GetComponent<TextMeshProUGUI>().text = (string)properties["mex5"];
                        }
                        text4.GetComponent<TextMeshProUGUI>().text = (string)properties["mex4"];
                    }
                    text3.GetComponent<TextMeshProUGUI>().text = (string)properties["mex3"];
                }
                text2.GetComponent<TextMeshProUGUI>().text = (string)properties["mex2"];
            }
            text1.GetComponent<TextMeshProUGUI>().text = (string)properties["mex1"];
        }
    }

    public override void OnRoomPropertiesUpdate(Hashtable propertiesThatChanged)
    {
        aggiorna();
    }
    
    public void playSuonoChipTry()
    {
        if(!PlayerPrefs.HasKey("volume"))
        {
            PlayerPrefs.SetFloat("volume", 1);
        }

        carta.volume = PlayerPrefs.GetFloat("volume");
        carta.Play();
    }
}