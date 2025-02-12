using UnityEngine;
using UnityEngine.UI;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab;  // Prefab della palla da spawnare
    public Transform spawnPoint;   // Punto in cui verrà spawnata la palla
    public Button spawnButton;     // Bottone per spawnare
    public Button resetButton;     // Bottone per resettare
    public Toggle passthroughToggle; // Toggle per attivare/disattivare il passthrough

    void Start()
    {
        // Collega il pulsante "Spawn" alla funzione SpawnBall
        if (spawnButton != null)
        {
            spawnButton.onClick.AddListener(SpawnBall);
        }

        // Collega il pulsante "Reset" alla funzione ResetBalls
        if (resetButton != null)
        {
            resetButton.onClick.AddListener(ResetBalls);
        }
    }

    public void SpawnBall()
    {
        // Controlla se il Toggle Passthrough è attivato
        if (passthroughToggle != null && passthroughToggle.isOn)
        {
            Debug.Log("Spawn bloccato: Passthrough è attivato.");
            return; // Blocca la creazione della palla
        }

        if (ballPrefab != null && spawnPoint != null)
        {
            Instantiate(ballPrefab, spawnPoint.position, Quaternion.identity);
            Debug.Log("Ball spawnata con successo!");
        }
        else
        {
            Debug.LogWarning("Assicurati di assegnare il prefab della ball e un punto di spawn!");
        }
    }

    public void ResetBalls()
    {
        // Trova tutte le palle nella scena con il tag "Ball"
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");

        foreach (GameObject ball in balls)
        {
            Destroy(ball);
        }
        Debug.Log("Tutte le palle sono state rimosse.");
    }
}
