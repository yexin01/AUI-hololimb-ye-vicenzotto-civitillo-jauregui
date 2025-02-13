using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CoachingUIManager : MonoBehaviour
{
    [Header("UI References")]
    public GameObject coachingUI;  // Il pannello Coaching UI
    public GameObject mainMenu;    // Il menu principale
    public GameObject videoObject; // Oggetto Video

    [Header("Steps Management")]
    public List<GameObject> steps = new List<GameObject>(); // Lista delle schede del coaching
    public TextMeshProUGUI continueButtonText;  // Testo del pulsante Continue
    public GameObject skipButton;  // Pulsante Skip
    private int currentStepIndex = 0;

    void Start()
    {
        ResetCoaching();  // Assicura che il sistema inizi dallo stato corretto
    }

    // Funzione chiamata quando premi "Relaunch"
    public void OpenCoachingUI()
    {
        Debug.Log("Opening Coaching UI");
        
        mainMenu.SetActive(false); // Nasconde il menu principale
        coachingUI.SetActive(true); // Mostra il Coaching UI

        ResetCoaching();  // Resetta i passaggi del tutorial alla prima scheda
    }

    // Funzione chiamata quando premi "Continue"
    public void ContinueStep()
    {
        Debug.Log($"Advancing from step {currentStepIndex}");

        // Disattiva il passo attuale
        steps[currentStepIndex].SetActive(false);

        // Se siamo all'ultimo step, chiudi il Coaching UI e riapri il menu
        if (currentStepIndex >= steps.Count - 1)
        {
            CloseAndResetCoachingUI();
            return;
        }

        // Passa al prossimo step
        currentStepIndex++;
        steps[currentStepIndex].SetActive(true);

        // Gestione dell'oggetto Video
        if (currentStepIndex == 1) // Step 2 (indice 1)
        {
            videoObject.SetActive(true);
        }
        else if (currentStepIndex == 2) // Step 3 (indice 2)
        {
            videoObject.SetActive(false);
        }

        // Aggiorna il testo del pulsante Continue se siamo all'ultimo step
        if (currentStepIndex == steps.Count - 1)
        {
            continueButtonText.text = "Done";
        }
    }

    // Funzione chiamata quando premi "Skip"
    public void SkipCoaching()
    {
        Debug.Log("Skipping Coaching UI");

        CloseAndResetCoachingUI(); // Chiude immediatamente e resetta
    }

    // Funzione per chiudere e resettare il tutorial
    private void CloseAndResetCoachingUI()
    {
        coachingUI.SetActive(false); // Nasconde il Coaching UI
        mainMenu.SetActive(true);    // Riapre il menu principale
        ResetCoaching();             // Reset per il prossimo avvio
    }

    // Reset del tutorial alla prima scheda
    private void ResetCoaching()
    {
        Debug.Log("Resetting Coaching UI");

        currentStepIndex = 0;

        // Attiva solo la prima scheda e disattiva le altre
        for (int i = 0; i < steps.Count; i++)
        {
            steps[i].SetActive(i == 0);
        }

        // Assicura che l'oggetto Video sia disattivato all'inizio
        videoObject.SetActive(false);

        // Reset del testo del pulsante Continue
        if (continueButtonText != null)
        {
            continueButtonText.text = "Continue";
        }

        // Assicura che il pulsante Skip sia attivo
        if (skipButton != null)
        {
            skipButton.SetActive(true);
        }
    }
}
