using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LogScript : MonoBehaviour
{
    public AudioSource carta, chip;
    public GameObject text;
    void Start()
    {
        if(!PlayerPrefs.HasKey("Log"))
            PlayerPrefs.SetString("Log", "");
        text.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetString("Log");
        
        if(!PlayerPrefs.HasKey("volume"))
        {
            PlayerPrefs.SetFloat("volume", 1);
        }

        chip.volume = PlayerPrefs.GetFloat("volume");
        chip.Play();
    }

    public void cancella()
    {
        PlayerPrefs.DeleteKey("Log");
        PlayerPrefs.SetString("Log", "");
        text.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetString("Log");
    }
    
    public void playSuonoChip()
    {
        if(!PlayerPrefs.HasKey("volume"))
        {
            PlayerPrefs.SetFloat("volume", 1);
        }

        carta.volume = PlayerPrefs.GetFloat("volume");
        carta.Play();
    }
}
