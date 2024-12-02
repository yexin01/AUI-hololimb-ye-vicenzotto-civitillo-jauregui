using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class MenuButtonHandler : MonoBehaviour
{
    public GameObject mainMenu; // Assegna il tuo Main Menu Setup qui nell'Inspector

    private void Update()
    {
        // Controlla se il pulsante "menu" del controller è stato premuto
        if (Keyboard.current.escapeKey.wasPressedThisFrame || // Per il test su PC
            XRControllerInput.GetMenuButton()) // Funzione per il controller VR
        {
            ToggleMenu();
        }
    }

    private void ToggleMenu()
    {
        // Cambia lo stato di attivazione del menu
        if (mainMenu != null)
        {
            mainMenu.SetActive(!mainMenu.activeSelf);
        }
    }
}

// Classe Helper per input VR
public static class XRControllerInput
{
    public static bool GetMenuButton()
    {
        // Ottiene lo stato dei pulsanti del controller
        var leftHand = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
        var rightHand = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);

        bool isLeftHandMenuButtonPressed = leftHand.TryGetFeatureValue(UnityEngine.XR.CommonUsages.menuButton, out bool leftMenuPressed) && leftMenuPressed;
        bool isRightHandMenuButtonPressed = rightHand.TryGetFeatureValue(UnityEngine.XR.CommonUsages.menuButton, out bool rightMenuPressed) && rightMenuPressed;

        return isLeftHandMenuButtonPressed || isRightHandMenuButtonPressed;
    }
}