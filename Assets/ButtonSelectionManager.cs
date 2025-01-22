using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonSelectionManager : MonoBehaviour
{
    [Header("Pulsanti di selezione")]
    public Button buttonLeft;
    public Button buttonRight;

    [Header("Pulsante di conferma")]
    public Button buttonConfirm;

    // Variabili booleane per tracciare quale pulsante è selezionato
    private bool isLeftSelected = false;
    private bool isRightSelected = false;

    private void Start()
    {
        // Se desidera partire con il pulsante "Confirm" disattivato
        buttonConfirm.interactable = false;
    }

    // Metodo chiamato quando viene cliccato il pulsante "Left"
    public void OnLeftButtonClick()
    {
        // Segna che "Left" è selezionato e "Right" non lo è più
        isLeftSelected = true;
        isRightSelected = false;

        // Aggiorna lo stato di interattività e/o aspetto
        UpdateButtonVisuals();
        buttonConfirm.interactable = true;  
    }

    // Metodo chiamato quando viene cliccato il pulsante "Right"
    public void OnRightButtonClick()
    {
        // Segna che "Right" è selezionato e "Left" non lo è più
        isRightSelected = true;
        isLeftSelected = false;

        // Aggiorna lo stato di interattività e/o aspetto
        UpdateButtonVisuals();
        buttonConfirm.interactable = true;
    }

    // Metodo chiamato quando viene cliccato il pulsante "Confirm"
    public void OnConfirmButtonClick()
    {
        // Se è selezionato "Left", carichiamo la Scena2
        if (isLeftSelected)
        {
            SceneManager.LoadScene("SampleScene"); //TODO: Cambiare con il nome della scena
        }
        // Altrimenti, se è selezionato "Right", carichiamo la Scena3
        else if (isRightSelected)
        {
            SceneManager.LoadScene("MovementRetargeting"); //TODO: Cambiare con il nome della scena
        }
        else
        {
            Debug.LogWarning("Nessun pulsante selezionato: impossibile confermare.");
        }
    }

    // Metodo per aggiornare l'aspetto dei pulsanti (colore, testo, ecc.)
    private void UpdateButtonVisuals()
    {
        // Esempio: cambia colore in base alla selezione
        Color selectedColor = Color.green;
        Color defaultColor = Color.white;

        // Se Left è selezionato
        if (isLeftSelected)
        {
            buttonLeft.image.color = selectedColor;
            buttonRight.image.color = defaultColor;
        }

        // Se Right è selezionato
        if (isRightSelected)
        {
            buttonLeft.image.color = defaultColor;
            buttonRight.image.color = selectedColor;
        }

        // Se, per qualche ragione, nessuno è selezionato
        if (!isLeftSelected && !isRightSelected)
        {
            buttonLeft.image.color = defaultColor;
            buttonRight.image.color = defaultColor;
        }
    }
}