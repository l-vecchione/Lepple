using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StartupScript : MonoBehaviour
{
    private GameObject _main, _ins, _backbtn1, _backbtn2, _backbtn3, _backbtn4, _opzioni, _lineeGuida, _tutorial;
    public AudioSource carta;
    
    // Start is called before the first frame update
    void OnEnable()
    {
        if(PlayerPrefs.HasKey("Ripetuto"))
            PlayerPrefs.DeleteKey("Ripetuto");
        PlayerPrefs.SetInt("Round",1);
        
        _main = GameObject.Find("Main");
        _ins = GameObject.Find("InserisciNome");
        _backbtn1 = GameObject.Find("BackButton1");
        _backbtn2 = GameObject.Find("BackButton2");
        _backbtn3 = GameObject.Find("BackButton3");
        _backbtn4 = GameObject.Find("BackButton4");
        _opzioni = GameObject.Find("Opzioni");
        _lineeGuida = GameObject.Find("LineeGuida");
        _tutorial = GameObject.Find("Tutorial");
        
        _opzioni.SetActive(false);
        _lineeGuida.SetActive(false);
        _tutorial.SetActive(false);
        _backbtn1.SetActive(false);
        _backbtn2.SetActive(false);
        _backbtn3.SetActive(false);
        _backbtn4.SetActive(false);
        
        if (!PlayerPrefs.HasKey("NomeUtente")) {
            _main.SetActive(false);
           _ins.SetActive(true);
           _backbtn1.SetActive(false);
        }
        else {
            _main.SetActive(true);
            _ins.SetActive(false);
            string nome = PlayerPrefs.GetString("NomeUtente");
            GameObject.Find("Saluto").GetComponent<TextMeshProUGUI>().text="Ciao, "+ nome + "!";
        }
        
        if(!PlayerPrefs.HasKey("volume"))
        {
            PlayerPrefs.SetFloat("volume", 1);
        }

        carta.volume = PlayerPrefs.GetFloat("volume");
        carta.Play();
    }

    public void opzioni()
    {
        _opzioni.SetActive(true);
        _main.SetActive(false);
        _backbtn2.SetActive(true);
        _lineeGuida.SetActive(false);
        _tutorial.SetActive(false);
        _ins.SetActive(false);
        GameObject volumeSlider = GameObject.Find("SliderVolume");
        volumeSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("volume");
    }
    public void cambiaNome()
    {
        _ins.SetActive(true);
       _main.SetActive(false);
       _backbtn1.SetActive(true);
       _lineeGuida.SetActive(false);
       _tutorial.SetActive(false);
       _opzioni.SetActive(false);
    }

    public void apriTutorial()
    {
        _main.SetActive(false);
        _tutorial.SetActive(true);
        _opzioni.SetActive(false);
        _lineeGuida.SetActive(false);
        _ins.SetActive(false);
        _backbtn4.SetActive(true);
    }
    
    public void apriLineeGuida()
    {
        _main.SetActive(false);
        _lineeGuida.SetActive(true);
        _tutorial.SetActive(false);
        _ins.SetActive(false);
        _opzioni.SetActive(false);
        _backbtn3.SetActive(true);
    }
    
    public void backToMenu()
    {
        _main.SetActive(true);
        _ins.SetActive(false);
        _backbtn1.SetActive(false);
        _backbtn2.SetActive(false);
        _backbtn3.SetActive(false);
        _backbtn4.SetActive(false);
        _opzioni.SetActive(false);
        _lineeGuida.SetActive(false);
        _tutorial.SetActive(false);
    }
    
    public void conferma()
    {
        string text = GameObject.Find("InputNome").GetComponent<TMP_InputField>().text;
        print(text);
        if(text.Equals(""))
            UnityEngine.Debug.Log("NomeVuoto");
        else
        {
            PlayerPrefs.SetString("NomeUtente", text);
            _main.SetActive(true);
            _ins.SetActive(false);
            _backbtn1.SetActive(false);
            string nome = PlayerPrefs.GetString("NomeUtente");
            GameObject.Find("Saluto").GetComponent<TextMeshProUGUI>().text="Ciao, "+ nome + "!";
        }
    }

    public void salvaOpzioni()
    {
        GameObject volumeSlider = GameObject.Find("SliderVolume");
        PlayerPrefs.SetFloat("volume", volumeSlider.GetComponent<Slider>().value);
        _main.SetActive(true);
        _opzioni.SetActive(false);
        _backbtn2.SetActive(false);
    }

    public void CambiaVolumeTry()
    {
        GameObject volumeSlider = GameObject.Find("SliderVolume");
        PlayerPrefs.SetFloat("volumeTry", volumeSlider.GetComponent<Slider>().value);
    }
    
    //VOLUME DEVE CAMBIARE NELLO SLIDER
}
