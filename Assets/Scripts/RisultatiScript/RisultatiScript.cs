using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class RisultatiScript : MonoBehaviour
{

    public GameObject text;
    public AudioSource carta;
    private void Awake()
    {
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.Disconnect();
        
        int risultato3 = PlayerPrefs.GetInt("Risultato");
        int risultato2 = PlayerPrefs.GetInt("Risultato2");
        int risultato = PlayerPrefs.GetInt("Risultato1");

        int risultot = risultato + risultato2 + risultato3;
        
        if(PlayerPrefs.HasKey("Ripetuto"))
            PlayerPrefs.DeleteKey("Ripetuto");
        
        if(!PlayerPrefs.HasKey("PuntiTotali"))
            PlayerPrefs.SetInt("PuntiTotali", 0);
        
        text.GetComponent<TextMeshProUGUI>().text= "Hai ricevuto " + risultot.ToString() + " punti!";
        PlayerPrefs.SetInt("PuntiTotali", PlayerPrefs.GetInt("PuntiTotali")+risultot);
        
        if(risultato==0 || risultato2==0 || risultato3==0)
            PlayerPrefs.SetInt("Ach2", 1);
        if(risultato==100 || risultato2 == 100 || risultato3 == 100)
            PlayerPrefs.SetInt("Ach3", 1);
        
        if(!PlayerPrefs.HasKey("Log"))
            PlayerPrefs.SetString("Log", "");
        String log = PlayerPrefs.GetString("Log");
        log = log + "Livello: " + PlayerPrefs.GetString("livello") + ", Punteggio: " + risultot + ", Data: " + DateTime.Now + "\n";
        PlayerPrefs.SetString("Log", log);
        
        if(!PlayerPrefs.HasKey("volume"))
        {
            PlayerPrefs.SetFloat("volume", 1);
        }

        carta.volume = PlayerPrefs.GetFloat("volume");
        carta.Play();
    }
    
}
