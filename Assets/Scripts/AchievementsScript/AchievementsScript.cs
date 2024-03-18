using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AchievementsScript : MonoBehaviour
{
    public GameObject puntiTot;
    public AudioSource chip;
    public GameObject image1, image2, image3, image4, image5, image6, image7, image8;
    public Sprite img1, img2, img3, img4, img5, img6, img7, img8;
    private void OnEnable()
    {
        int punti = PlayerPrefs.GetInt("PuntiTotali");
        puntiTot.GetComponent<TextMeshProUGUI>().text = "Punti totali ottenuti: " + PlayerPrefs.GetInt("PuntiTotali");
        if(!PlayerPrefs.HasKey("volume"))
        {
            PlayerPrefs.SetFloat("volume", 1);
        }

        chip.volume = PlayerPrefs.GetFloat("volume");
        chip.Play();


        if (!PlayerPrefs.HasKey("Ach1"))
            PlayerPrefs.SetInt("Ach1", 0);
        if (!PlayerPrefs.HasKey("Ach2"))
            PlayerPrefs.SetInt("Ach2", 0);
        if (!PlayerPrefs.HasKey("Ach3"))
            PlayerPrefs.SetInt("Ach3", 0);
        if (!PlayerPrefs.HasKey("Ach4"))
            PlayerPrefs.SetInt("Ach4", 0);
        if (!PlayerPrefs.HasKey("Ach5"))
            PlayerPrefs.SetInt("Ach5", 0);
        if (!PlayerPrefs.HasKey("Ach6"))
            PlayerPrefs.SetInt("Ach6", 0);
        if (!PlayerPrefs.HasKey("Ach7"))
            PlayerPrefs.SetInt("Ach7", 0);
        if (!PlayerPrefs.HasKey("Ach8"))
            PlayerPrefs.SetInt("Ach8", 0);

        if (punti >= 100)
        {
            PlayerPrefs.SetInt("Ach1", 1);
        }
        if (punti >= 250)
        {
            PlayerPrefs.SetInt("Ach5", 1);
        }
        if (punti >= 500)
        {
            PlayerPrefs.SetInt("Ach6", 1);
        }
        if (punti >= 1000)
        {
            PlayerPrefs.SetInt("Ach7", 1);
        }
        if (punti >= 2000)
        {
            PlayerPrefs.SetInt("Ach8", 1);
        }

        if (PlayerPrefs.GetInt("Ach1") == 1)
        {
            image1.GetComponent<Image>().sprite = img1;
            Color temp = image1.GetComponent<Image>().color;
            temp.a = 1;
            image1.GetComponent<Image>().color = temp;
        }
        
        if (PlayerPrefs.GetInt("Ach2") == 1)
        {
            image2.GetComponent<Image>().sprite = img2;
            Color temp = image2.GetComponent<Image>().color;
            temp.a = 1;
            image2.GetComponent<Image>().color = temp;
        }
        
        if (PlayerPrefs.GetInt("Ach3") == 1)
        {
            image3.GetComponent<Image>().sprite = img3;
            Color temp = image1.GetComponent<Image>().color;
            temp.a = 1;
            image3.GetComponent<Image>().color = temp;
        }
        
        if (PlayerPrefs.GetInt("Ach4") == 1)
        {
            image4.GetComponent<Image>().sprite = img4;
            Color temp = image1.GetComponent<Image>().color;
            temp.a = 1;
            image4.GetComponent<Image>().color = temp;
        }
        
        if (PlayerPrefs.GetInt("Ach5") == 1)
        {
            image5.GetComponent<Image>().sprite = img5;
            Color temp = image1.GetComponent<Image>().color;
            temp.a = 1;
            image5.GetComponent<Image>().color = temp;
        }
        
        if (PlayerPrefs.GetInt("Ach6") == 1)
        {
            image6.GetComponent<Image>().sprite = img6;
            Color temp = image1.GetComponent<Image>().color;
            temp.a = 1;
            image6.GetComponent<Image>().color = temp;
        }
        
        if (PlayerPrefs.GetInt("Ach7") == 1)
        {
            image7.GetComponent<Image>().sprite = img7;
            Color temp = image1.GetComponent<Image>().color;
            temp.a = 1;
            image7.GetComponent<Image>().color = temp;
        }
        
        if (PlayerPrefs.GetInt("Ach8") == 1)
        {
            image8.GetComponent<Image>().sprite = img8;
            Color temp = image1.GetComponent<Image>().color;
            temp.a = 1;
            image8.GetComponent<Image>().color = temp;
        }
    }
}
