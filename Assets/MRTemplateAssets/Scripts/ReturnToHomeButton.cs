using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReturnToHomeButton : MonoBehaviour
{
    // Assegna il bottone direttamente dall'Inspector
    [SerializeField]
    private Button returnButton;

    void Start()
    {
        if (returnButton == null)
        {
            Debug.LogError("Il riferimento al bottone non è stato assegnato.");
            return;
        }

        // Aggiunge il listener per il click del bottone
        returnButton.onClick.AddListener(ReturnToHome);
    }

    void ReturnToHome()
    {
        Debug.Log("Ritorno alla Home di Meta Quest...");
        
        // Esegui il comando per chiudere l'applicazione
        Application.Quit();
    }
}