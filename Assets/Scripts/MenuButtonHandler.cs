using UnityEngine;
using UnityEngine.InputSystem; // For keyboard input
using UnityEngine.XR; // For XR InputDevices

public class MenuButtonHandler : MonoBehaviour
{
    public GameObject mainMenu; // Assign your Main Menu Setup here in the Inspector
    private bool isMenuButtonPressed = false; // To track button press state

    private void Update()
    {
        // Only toggle menu if the proper input is detected
        if (Keyboard.current.escapeKey.isPressed || // For PC testing
            IsMenuButtonPressed() ||
            (IsPinchGestureDetected() && !isMenuButtonPressed)) // Pinch gesture only works once per press
        {
            if (!isMenuButtonPressed)
            {
                ToggleMenu();
                isMenuButtonPressed = true; // Mark as pressed
            }
        }
        else
        {
            isMenuButtonPressed = false; // Reset when inputs are released
        }
    }

    private void ToggleMenu()
    {
        if (mainMenu != null)
        {
            mainMenu.SetActive(!mainMenu.activeSelf);
            Debug.Log("Menu toggled. New state: " + mainMenu.activeSelf);
        }
        else
        {
            Debug.LogError("Main Menu is not assigned in the Inspector!");
        }
    }

    private bool IsMenuButtonPressed()
    {
        var leftHand = UnityEngine.XR.InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
        var rightHand = UnityEngine.XR.InputDevices.GetDeviceAtXRNode(XRNode.RightHand);

        bool leftMenuPressed = leftHand.TryGetFeatureValue(UnityEngine.XR.CommonUsages.menuButton, out bool leftPressed) && leftPressed;
        bool rightMenuPressed = rightHand.TryGetFeatureValue(UnityEngine.XR.CommonUsages.menuButton, out bool rightPressed) && rightPressed;

        if (leftMenuPressed || rightMenuPressed)
        {
            Debug.Log("Menu button pressed!{menuButtonPressed}");
        }

        return leftMenuPressed || rightMenuPressed;
    }

    private bool IsPinchGestureDetected()
    {
        // Check for hand tracking pinch gesture
        var leftHand = UnityEngine.XR.InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
        var rightHand = UnityEngine.XR.InputDevices.GetDeviceAtXRNode(XRNode.RightHand);

        // Check for a valid pinch on left or right hand
        return IsPinching(leftHand) || IsPinching(rightHand);
    }

    private bool IsPinching(UnityEngine.XR.InputDevice handDevice)
    {
        if (!handDevice.isValid) return false;

        // Pinch detection for hand tracking
        if (handDevice.TryGetFeatureValue(UnityEngine.XR.CommonUsages.grip, out float gripValue))
        {
            // Adjust the threshold for detecting a "pinch" gesture
            return gripValue > 0.8f; // Customize threshold
        }

        return false;
    }
}