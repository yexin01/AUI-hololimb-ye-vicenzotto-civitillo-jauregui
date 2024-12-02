using UnityEngine;
using TMPro;

public class StopwatchController : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Collegare il testo dall'Inspector
    private float timer;             // Variabile per tracciare il tempo
    private bool isRunning;          // Per controllare se il cronometro sta girando

    void Start()
    {
        // Inizializza il cronometro quando parte il progetto
        timer = 0f;
        isRunning = true; // Avvia il cronometro automaticamente
    }

    void Update()
    {
        if (isRunning)
        {
            timer += Time.deltaTime; // Incrementa il tempo ogni frame
            UpdateTimerDisplay();   // Aggiorna il testo del timer
        }

        // Mantieni il cronometro davanti alla persona
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        if (Camera.main != null)
        {
            // Posiziona l'oggetto 1.5 unità davanti alla fotocamera
            transform.position = Camera.main.transform.position + Camera.main.transform.forward * 1.5f;

            // Mantieni il cronometro rivolto verso la fotocamera
            transform.LookAt(Camera.main.transform);
            transform.Rotate(0, 180, 0); // Ruota di 180 gradi per mostrare il fronte
        }
    }

    private void UpdateTimerDisplay()
    {
        // Calcola ore, minuti e secondi
        int hours = Mathf.FloorToInt(timer / 3600f);
        int minutes = Mathf.FloorToInt((timer % 3600f) / 60f);
        int seconds = Mathf.FloorToInt(timer % 60f);

        // Aggiorna il testo con il formato HH:MM:SS
        timerText.text = $"{hours:00}:{minutes:00}:{seconds:00}";
    }

    // Metodo per fermare o riprendere il cronometro (opzionale)
    public void ToggleTimer()
    {
        isRunning = !isRunning;
    }

    // Metodo per resettare il cronometro (opzionale)
    public void ResetTimer()
    {
        timer = 0f;
        UpdateTimerDisplay();
    }
}