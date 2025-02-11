using UnityEngine;
using UnityEngine.UI; // For working with the Slider component

public class ChangeArmOpacity : MonoBehaviour
{
    // Assign these in the Inspector
    public Material ArmMaterial; // The material whose opacity you want to control
    public Slider OpacitySlider; // The UI Slider to control the opacity

    public void UpdateOpacity()
    {
        if (ArmMaterial != null)
        {
            // Get the current color of the material
            Color color = ArmMaterial.color;

            // Set the alpha value based on the slider's value (0 to 1)
            color.a = OpacitySlider.value;

            // Assign the modified color back to the material
            ArmMaterial.color = color;

            Debug.Log($"ArmMaterial opacity set to {OpacitySlider.value * 100}%.");
        }
        else
        {
            Debug.LogError("ArmMaterial is not assigned!");
        }
    }

}