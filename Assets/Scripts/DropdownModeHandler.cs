using UnityEngine;
using TMPro;

public class VisualizationModeHandler : MonoBehaviour
{
    public TMP_Dropdown dropdown; // Collega il Dropdown nell'Inspector

    void Start()
    {
        // Controlla che i riferimenti siano assegnati
        if (dropdown == null)
        {
            Debug.LogError("Dropdown non assegnato nello script VisualizationModeHandler.");
            return;
        }

        // Imposta Mirror Mode come modalità iniziale
        dropdown.value = 0;

        // Aggiungi il listener per rilevare i cambiamenti
        dropdown.onValueChanged.AddListener(OnDropdownValueChanged);

        // Debug per confermare che tutto sia pronto
        Debug.Log("Modalità iniziale: Mirror Mode");
    }

    void OnDropdownValueChanged(int index)
    {
        // Debug per verificare la modalità selezionata
        switch (index)
        {
            case 0:
                Debug.Log("Modalità selezionata: Mirror Mode");
                break;
            case 1:
                Debug.Log("Modalità selezionata: Static Mode");
                break;
            default:
                Debug.LogWarning("Modalità sconosciuta selezionata.");
                break;
        }

        // Chiude la tendina del Dropdown
        dropdown.Hide();
    }
}