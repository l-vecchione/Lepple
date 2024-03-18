using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    public AudioSource carta, chip;
    public void exitGame()
    {
        Application.Quit();
    }

    public void playSuonoCarta()
    {
        if(!PlayerPrefs.HasKey("volume"))
        {
            PlayerPrefs.SetFloat("volume", 1);
        }

        carta.volume = PlayerPrefs.GetFloat("volume");
        carta.Play();
    }
    
    public void playSuonoChip()
    {
        if(!PlayerPrefs.HasKey("volume"))
        {
            PlayerPrefs.SetFloat("volume", 1);
        }

        chip.volume = PlayerPrefs.GetFloat("volume");
        chip.Play();
    }

    public void playSuonoChipTry()
    {
        chip.volume = PlayerPrefs.GetFloat("volumeTry");
        chip.Play();
    }
}
