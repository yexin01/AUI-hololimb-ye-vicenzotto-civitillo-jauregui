using UnityEngine;
using UnityEngine.InputSystem;

public class MenuToggle : MonoBehaviour
{
    public GameObject menuCanvas; // Assign the Canvas here in the Inspector

    private void Update()
    {
        // Check if the Menu button on the Oculus controller is pressed
        if (OVRInput.GetDown(OVRInput.Button.Start))
        {
            ToggleMenu();
        }
    }

    private void ToggleMenu()
    {
        // Toggle the Canvas's active state
        menuCanvas.SetActive(!menuCanvas.activeSelf);
    }
}
