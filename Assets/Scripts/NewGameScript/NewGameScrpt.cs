using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class NewGameScrpt : MonoBehaviourPunCallbacks
{
    private GameObject _newGame, _scegliCarta;
    public GameObject testoInfo;
    public AudioSource carta;
    public string[,] livelli;
    public string[,] valori;
    public EventSystem eventSystem;
    public GameObject continua;
    private int livello;

    public void Start()
    {
        if(!PlayerPrefs.HasKey("Ripetuto"))
            PlayerPrefs.SetInt("Ripetuto", 0);
        if (!PhotonNetwork.IsMasterClient) return;
        //Hashtable properties = new Hashtable();
        //PhotonNetwork.CurrentRoom.CustomProperties.Clear();
        
        //properties.Add("livello", livello);
        //PhotonNetwork.CurrentRoom.SetCustomProperties(properties);
        
        if(!PlayerPrefs.HasKey("volume"))
        {
            PlayerPrefs.SetFloat("volume", 1);
        }

        carta.volume = PlayerPrefs.GetFloat("volume");
        carta.Play();
    }

    public override void OnEnable()
    {
        livelli = new string[5, 3];
        valori = new string[5, 3];
        popolaLivelli();

        livello = (int)PhotonNetwork.CurrentRoom.CustomProperties["livello"];
        
        testoInfo.GetComponent<TextMeshProUGUI>().text = livelli[livello, 2];
        PlayerPrefs.SetString("StimaReale", valori[livello, 2]);

        int round = PlayerPrefs.GetInt("Round");

        if (round == 3)
        {
            testoInfo.GetComponent<TextMeshProUGUI>().text = livelli[livello, 2];
            PlayerPrefs.SetString("StimaReale", valori[livello, 2]);
        }
        else if (round==2)
        {
            testoInfo.GetComponent<TextMeshProUGUI>().text = livelli[livello, 1];
            PlayerPrefs.SetString("StimaReale", valori[livello, 1]);
        }
        else if (round==1)
        {
            testoInfo.GetComponent<TextMeshProUGUI>().text = livelli[livello, 0];
            PlayerPrefs.SetString("StimaReale", valori[livello, 0]);
        }

        _newGame = GameObject.Find("StoryInfo");
        _scegliCarta = GameObject.Find("SelezioneCarta");

        _newGame.SetActive(true);
        continua.SetActive(false);
        _scegliCarta.SetActive(false);
        
        base.OnEnable();
    }

    public void backToGame()
    {
        _scegliCarta.SetActive(false);
        _newGame.SetActive(true);
    }

    public void scegliCarta()
    {
        _scegliCarta.SetActive(true);
        _newGame.SetActive(false);
    }

    public void playSuonoCarta()
    {
        if (!PlayerPrefs.HasKey("volume"))
        {
            PlayerPrefs.SetFloat("volume", 1);
        }

        carta.volume = PlayerPrefs.GetFloat("volume");
        carta.Play();
    }

    public void popolaLivelli()
    {
        livelli[0,0] = "Contesto:\nProgetto: e-commerce.\nGrandezza del team: 10 membri.\nEsperienza: 2-3 anni in media.\nFamiliarità con le tecnologie: base.\nDurata degli Sprint: 2 settimane.\nNumero di Sprint: 2.\n\nUser Story:\nCome cliente, voglio essere in grado di aggiungere prodotti al mio carrello, in modo da poterli acquistare tutti insieme.\nCriteri di Accettazione:\n1.\tQuando un cliente visualizza un prodotto, dovrebbe vedere un’opzione per aggiungere il prodotto al carrello.\n2.\tQuando un cliente aggiunge un prodotto al carrello, il numero di articoli nel carrello dovrebbe aumentare.\n3.\tIl cliente dovrebbe essere in grado di visualizzare tutti gli articoli nel suo carrello.\n4.\tIl cliente dovrebbe essere in grado di rimuovere articoli dal carrello.\n";
        valori[0,0] = "5";
        
        livelli[0,1] = "Contesto:\nProgetto: e-commerce.\nGrandezza del team: 10 membri.\nEsperienza: 2-3 anni in media.\nFamiliarità con le tecnologie: base.\nDurata degli Sprint: 2 settimane.\nNumero di Sprint: 2.\n\nUser Story:\nCome amministratore del sito, voglio essere in grado di gestire l'inventario dei prodotti, in modo da poter aggiungere, rimuovere o modificare i dettagli dei prodotti.\nCriteri di Accettazione:\n1.\tL’amministratore del sito dovrebbe essere in grado di visualizzare tutti i prodotti nell’inventario.\n2.\tL’amministratore del sito dovrebbe essere in grado di aggiungere nuovi prodotti all’inventario.\n3.\tL’amministratore del sito dovrebbe essere in grado di rimuovere i prodotti dall’inventario.\n4.\tL’amministratore del sito dovrebbe essere in grado di modificare i dettagli dei prodotti nell’inventario.\n5.\tLe modifiche all’inventario dovrebbero essere immediatamente visibili ai clienti sul sito.\n";
        valori[0,1] = "13";
        
        livelli[0,2] = "Contesto:\nProgetto: e-commerce.\nGrandezza del team: 10 membri.\nEsperienza: 2-3 anni in media.\nFamiliarità con le tecnologie: base.\nDurata degli Sprint: 2 settimane.\nNumero di Sprint: 2.\n\nUser Story:\nCome cliente, voglio essere in grado di cercare prodotti per categoria, in modo da poter trovare facilmente ciò che sto cercando.\nCriteri di Accettazione:\n1.\tI clienti dovrebbero essere in grado di visualizzare una lista di categorie di prodotti.\n2.\tI clienti dovrebbero essere in grado di selezionare una categoria e visualizzare tutti i prodotti in quella categoria.\n3.\tI risultati della ricerca dovrebbero includere dettagli del prodotto come nome, immagine, prezzo e descrizione.\n4.\tI clienti dovrebbero essere in grado di tornare ai risultati della ricerca dopo aver visualizzato i dettagli di un prodotto.\n";
        valori[0,2] = "8";

        
        
        livelli[1,0] = "Contesto:\nProgetto: app per un ristorante.\nGrandezza del team: 15 membri.\nEsperienza: 5 anni in media.\nFamiliarità con le tecnologie: elevata.\nDurata degli Sprint: 4 settimane.\nNumero di Sprint: 1.\n\nUser Story:\nCome proprietario del ristorante, voglio essere in grado di gestire un sistema di prenotazione di tavoli nell'app, in modo da poter ottimizzare l'organizzazione del ristorante.\nCriteri di Accettazione:\n1.\tIl proprietario del ristorante dovrebbe essere in grado di visualizzare tutte le prenotazioni attuali.\n2.\tIl proprietario del ristorante dovrebbe essere in grado di aggiungere, modificare o cancellare prenotazioni.\n3.\tIl sistema di prenotazione dovrebbe tener conto della capacità del ristorante e dei tempi di prenotazione.\n4.\tI clienti dovrebbero ricevere una conferma della loro prenotazione.\n5.\tIl sistema di prenotazione dovrebbe essere integrato con l’app esistente.\n\n";
        valori[1,0] = "20";
        
        livelli[1,1] = "Contesto:\nProgetto: app per un ristorante.\nGrandezza del team: 15 membri.\nEsperienza: 5 anni in media.\nFamiliarità con le tecnologie: elevata.\nDurata degli Sprint: 4 settimane.\nNumero di Sprint: 1.\n\nUser Story:\nCome cliente, voglio essere in grado di visualizzare il menu del ristorante nell'app, in modo da poter decidere cosa ordinare.\nCriteri di Accettazione:\n1.\tI clienti dovrebbero essere in grado di visualizzare una lista di piatti disponibili nel menu.\n2.\tI clienti dovrebbero essere in grado di vedere i dettagli di ogni piatto, come ingredienti, prezzo e una breve descrizione.\n3.\tI clienti dovrebbero essere in grado di cercare piatti specifici nel menu.\n";
        valori[1,1] = "5";
        
        livelli[1,2] = "Contesto:\nProgetto: app per un ristorante.\nGrandezza del team: 15 membri.\nEsperienza: 5 anni in media.\nFamiliarità con le tecnologie: elevata.\nDurata degli Sprint: 4 settimane.\nNumero di Sprint: 1.\n\nUser Story:\nCome cliente, voglio essere in grado di effettuare ordini direttamente dall'app, in modo da poter ordinare il cibo senza dover chiamare o visitare il ristorante.\nCriteri di Accettazione:\n1.\tI clienti dovrebbero essere in grado di selezionare i piatti dal menu e aggiungerli al loro ordine.\n2.\tI clienti dovrebbero essere in grado di visualizzare un riepilogo del loro ordine prima di confermarlo.\n3.\tI clienti dovrebbero ricevere una conferma dell’ordine dopo averlo effettuato.\n4.\tI clienti dovrebbero essere in grado di visualizzare lo stato del loro ordine in tempo reale.\n\n";
        valori[1,2] = "8";
        
        
        
        livelli[4,0] = "Contesto:\nProgetto: creazione di un blog.\nGrandezza del team: 2 membri.\nEsperienza: 2 anni in media.\nFamiliarità con le tecnologie: base.\nDurata degli Sprint: 1 settimana.\nNumero di Sprint: 3.\n\nUser Story:\nCome autore del blog, voglio essere in grado di creare, modificare e pubblicare i post del blog, in modo da poter mantenere facilmente aggiornato il mio blog.\nCriteri di Accettazione:\n1.\tL’autore del blog dovrebbe essere in grado di creare un nuovo post del blog.\n2.\tL’autore del blog dovrebbe essere in grado di modificare i post del blog esistenti.\n3.\tL’autore del blog dovrebbe essere in grado di pubblicare i post del blog, rendendoli visibili ai lettori.\n4.\tI post del blog dovrebbero supportare la formattazione del testo, come grassetto, corsivo, elenchi puntati, ecc.\n";
        valori[4,0] = "8";
        
        livelli[4,1] = "Contesto:\nProgetto: creazione di un blog.\nGrandezza del team: 2 membri.\nEsperienza: 2 anni in media.\nFamiliarità con le tecnologie: base.\nDurata degli Sprint: 1 settimana.\nNumero di Sprint: 3.\n\nUser Story:\nCome autore del blog, voglio essere in grado di gestire i commenti dei lettori sui miei post, in modo da poter interagire con i miei lettori e moderare la discussione.\nCriteri di Accettazione:\n1.\tI lettori dovrebbero essere in grado di lasciare commenti sui post del blog.\n2.\tL’autore del blog dovrebbe essere in grado di visualizzare tutti i commenti su un post.\n3.\tL’autore del blog dovrebbe essere in grado di rispondere ai commenti.\n4.\tL’autore del blog dovrebbe essere in grado di moderare i commenti, compreso l’eliminazione dei commenti inappropriati.\n";
        valori[4,1] = "13";
        
        livelli[4,2] = "Contesto:\nProgetto: creazione di un blog.\nGrandezza del team: 2 membri.\nEsperienza: 2 anni in media.\nFamiliarità con le tecnologie: base.\nDurata degli Sprint: 1 settimana.\nNumero di Sprint: 3.\n\nUser Story:\nCome lettore del blog, voglio essere in grado di visualizzare l'elenco dei post recenti sulla homepage, in modo da poter facilmente trovare i contenuti più recenti.\nCriteri di Accettazione:\n1.\tI lettori dovrebbero vedere un elenco dei post più recenti quando visitano la homepage del blog.\n2.\tI lettori dovrebbero essere in grado di cliccare su un post per leggerlo completamente.\n";
        valori[4,2] = "2";
        
        
        
        livelli[2,0] = "Contesto:\nProgetto: sito per la gestione di un canile.\nGrandezza del team: 8 membri.\nEsperienza: 6 anni in media.\nFamiliarità con le tecnologie: elevata.\nDurata degli Sprint: 2 settimane.\nNumero di Sprint: 3.\n\nUser Story:\nCome gestore del canile, voglio essere in grado di tracciare e gestire la salute e le vaccinazioni di ogni cane, in modo da poter garantire il benessere di ogni animale nel canile.\nCriteri di Accettazione:\n1.\tIl gestore del canile dovrebbe essere in grado di registrare e visualizzare le informazioni sulla salute di ogni cane, compresi i dettagli sulle vaccinazioni.\n2.\tIl gestore del canile dovrebbe ricevere promemoria per le future vaccinazioni o controlli di salute per ogni cane.\n3.\tIl sistema dovrebbe essere in grado di generare report sulla salute di ogni cane, compresi i dettagli sulle vaccinazioni passate e future.\n";
        valori[2,0] = "13";
        
        livelli[2,1] = "Contesto:\nProgetto: sito per la gestione di un canile.\nGrandezza del team: 8 membri.\nEsperienza: 6 anni in media.\nFamiliarità con le tecnologie: elevata.\nDurata degli Sprint: 2 settimane.\nNumero di Sprint: 3.\n\nUser Story:\nCome visitatore del sito, voglio essere in grado di visualizzare l'indirizzo e l'orario di apertura del canile, in modo da poter pianificare la mia visita.\nCriteri di Accettazione:\n1.\tI visitatori dovrebbero vedere l’indirizzo e l’orario di apertura del canile sulla homepage del sito.\n";
        valori[2,1] = "\u00bd";
        
        livelli[2,2] = "Contesto:\nProgetto: sito per la gestione di un canile.\nGrandezza del team: 8 membri.\nEsperienza: 6 anni in media.\nFamiliarità con le tecnologie: elevata.\nDurata degli Sprint: 2 settimane.\nNumero di Sprint: 3.\n\nUser Story:\nCome gestore del canile, voglio essere in grado di gestire un sistema completo di adozione di cani attraverso il sito, in modo da poter facilitare il processo di adozione per i potenziali proprietari di animali domestici.\nCriteri di Accettazione:\n1.\tIl gestore del canile dovrebbe essere in grado di elencare i cani disponibili per l’adozione, con dettagli come età, razza, salute e personalità.\n2.\tI potenziali proprietari di animali domestici dovrebbero essere in grado di visualizzare l’elenco dei cani disponibili per l’adozione.\n3.\tI potenziali proprietari di animali domestici dovrebbero essere in grado di compilare un modulo di richiesta di adozione attraverso il sito.\n4.\tIl gestore del canile dovrebbe essere in grado di rivedere e approvare le richieste di adozione.\n5.\tIl sistema dovrebbe inviare una notifica al potenziale proprietario dell’animale domestico una volta che la richiesta di adozione è stata approvata.\n";
        valori[2,2] = "20";
        
        
        
        livelli[3,0] = "Contesto:\nProgetto: servizio di messagistica.\nGrandezza del team: 20 membri.\nEsperienza: 3 anni in media.\nFamiliarità con le tecnologie: media.\nDurata degli Sprint: 4 settimane.\nNumero di Sprint: 2.\n\nUser Story:\nCome utente del servizio di messaggistica, voglio essere in grado di creare e gestire gruppi di chat, in modo da poter comunicare con più persone contemporaneamente.\nCriteri di Accettazione:\n1.\tGli utenti dovrebbero essere in grado di creare un nuovo gruppo di chat.\n2.\tGli utenti dovrebbero essere in grado di aggiungere o rimuovere membri dal gruppo di chat.\n3.\tGli utenti dovrebbero essere in grado di inviare messaggi al gruppo di chat che sono visibili a tutti i membri.\n";
        valori[3,0] = "5";
        
        livelli[3,1] = "Contesto:\nProgetto: servizio di messagistica.\nGrandezza del team: 20 membri.\nEsperienza: 3 anni in media.\nFamiliarità con le tecnologie: media.\nDurata degli Sprint: 4 settimane.\nNumero di Sprint: 2.\n\nUser Story:\nCome utente del servizio di messaggistica, voglio essere in grado di inviare e ricevere messaggi multimediali (come immagini e video), in modo da poter condividere più tipi di contenuti con i miei contatti.\nCriteri di Accettazione:\n1.\tGli utenti dovrebbero essere in grado di selezionare e inviare file multimediali attraverso la chat.\n2.\tGli utenti dovrebbero essere in grado di visualizzare i messaggi multimediali ricevuti all’interno della chat.\n3.\tIl sistema dovrebbe supportare formati di file comuni come JPEG per le immagini e MP4 per i video.\n";
        valori[3,1] = "8";
        
        livelli[3,2] = "Contesto:\nProgetto: servizio di messagistica.\nGrandezza del team: 20 membri.\nEsperienza: 3 anni in media.\nFamiliarità con le tecnologie: media.\nDurata degli Sprint: 4 settimane.\nNumero di Sprint: 2.\n\nUser Story:\nCome utente del servizio di messaggistica, voglio essere in grado di cambiare il mio stato online/offline, in modo da poter comunicare la mia disponibilità ai miei contatti.\nCriteri di Accettazione:\n1.\tGli utenti dovrebbero essere in grado di cambiare il loro stato in online o offline.\n2.\tGli utenti dovrebbero essere in grado di vedere lo stato online/offline dei loro contatti.\n";
        valori[3,2] = "3";
    }

    public void cartaScelta()
    {
        int rip=PlayerPrefs.GetInt("Ripetuto");
        int round = PlayerPrefs.GetInt("Round");

        Hashtable properties = PhotonNetwork.CurrentRoom.CustomProperties;
        
        //properties.Remove(""+PhotonNetwork.LocalPlayer.NickName);
        
        GameObject selected = eventSystem.currentSelectedGameObject;
        
        if (selected == GameObject.Find("Carta0"))
            properties["" + PhotonNetwork.LocalPlayer.NickName+rip+round] = "0";
        else if(selected==GameObject.Find("Carta1/2"))
            properties["" + PhotonNetwork.LocalPlayer.NickName+rip+round] = "\u00bd";
        else if(selected==GameObject.Find("Carta1"))
            properties["" + PhotonNetwork.LocalPlayer.NickName+rip+round] = "1";
        else if(selected==GameObject.Find("Carta2"))
            properties["" + PhotonNetwork.LocalPlayer.NickName+rip+round] = "2";
        else if(selected==GameObject.Find("Carta3"))
            properties["" + PhotonNetwork.LocalPlayer.NickName+rip+round] = "3";
        else if(selected==GameObject.Find("Carta5"))
            properties["" + PhotonNetwork.LocalPlayer.NickName+rip+round] = "5";
        else if(selected==GameObject.Find("Carta8"))
            properties["" + PhotonNetwork.LocalPlayer.NickName+rip+round] = "8";
        else if(selected==GameObject.Find("Carta13"))
            properties["" + PhotonNetwork.LocalPlayer.NickName+rip+round] = "13";
        else if(selected==GameObject.Find("Carta20"))
            properties["" + PhotonNetwork.LocalPlayer.NickName+rip+round] = "20";
        else if(selected==GameObject.Find("Carta40"))
            properties["" + PhotonNetwork.LocalPlayer.NickName+rip+round] = "40";
        else if(selected==GameObject.Find("Carta100"))
            properties["" + PhotonNetwork.LocalPlayer.NickName+rip+round] = "100";
        else if(selected==GameObject.Find("Carta?"))
            properties["" + PhotonNetwork.LocalPlayer.NickName+rip+round] = "?";
        else if(selected==GameObject.Find("CartaInfinito"))
            properties["" + PhotonNetwork.LocalPlayer.NickName+rip+round] = "\u221e";
        
        PhotonNetwork.CurrentRoom.SetCustomProperties(properties);
        
        Debug.Log(PhotonNetwork.LocalPlayer.NickName+rip+round);
        
        //if(PhotonNetwork.IsMasterClient)
        //    OnRoomPropertiesUpdate(null);
    }
    
    
    public override void OnRoomPropertiesUpdate(Hashtable propertiesThatChanged)
    {
        if (!PhotonNetwork.IsMasterClient) return;

        int rip = PlayerPrefs.GetInt("Ripetuto");
        int round = PlayerPrefs.GetInt("Round");
        
        Player[] players = PhotonNetwork.PlayerList;
        Hashtable properties = PhotonNetwork.CurrentRoom.CustomProperties;

        bool contiene=true;
        

        foreach (Player player in players)
        {
            if (!properties.ContainsKey(""+player.NickName+rip+round))
            {
                contiene = false;
                break;
            }
        }
        

        if (contiene) continua.SetActive(true);


    }

    public void LoadScopriCarte()
    {
        if(PhotonNetwork.IsMasterClient)
            PhotonNetwork.LoadLevel("ScopriCarte");
    }
}