using UnityEngine;
using UnityEngine.UI;

public class ChangeArmOpacity : MonoBehaviour
{
    // Assign these in the Inspector
    public Material ArmMaterial; // The material whose opacity you want to control
    public Button button100; 
    public Button button70;
    public Button button40;
    public Button button10;

    public void SetOpacity100()
    {
        if (ArmMaterial != null)
        {
            // Get the current color of the material
            Color color = ArmMaterial.color;

            // Set the alpha value
            color.a = 1.00F;

            // Assign the modified color back to the material
            ArmMaterial.color = color;
            UpdateButtonVisuals(button100);

            Debug.Log($"ArmMaterial opacity set to 100%.");
        }
        else
        {
            Debug.LogError("ArmMaterial is not assigned!");
        }
    }

    public void SetOpacity70()
    {
        if (ArmMaterial != null)
        {
            // Get the current color of the material
            Color color = ArmMaterial.color;

            // Set the alpha value
            color.a = 0.70F;

            // Assign the modified color back to the material
            ArmMaterial.color = color;
            UpdateButtonVisuals(button70);

            Debug.Log($"ArmMaterial opacity set to 70%.");
        }
        else
        {
            Debug.LogError("ArmMaterial is not assigned!");
        }
    }

    public void SetOpacity40()
    {
        if (ArmMaterial != null)
        {
            // Get the current color of the material
            Color color = ArmMaterial.color;

            // Set the alpha value
            color.a = 0.40F;

            // Assign the modified color back to the material
            ArmMaterial.color = color;
            UpdateButtonVisuals(button40);

            Debug.Log($"ArmMaterial opacity set to 40%.");
        }
        else
        {
            Debug.LogError("ArmMaterial is not assigned!");
        }
    }

    public void SetOpacity10()
    {
        if (ArmMaterial != null)
        {
            // Get the current color of the material
            Color color = ArmMaterial.color;

            // Set the alpha value
            color.a = 0.10F;

            // Assign the modified color back to the material
            ArmMaterial.color = color;
            UpdateButtonVisuals(button10);

            Debug.Log($"ArmMaterial opacity set to 10%.");
        }
        else
        {
            Debug.LogError("ArmMaterial is not assigned!");
        }
    }

    private void UpdateButtonVisuals(Button selected)
    {
        Color selectedColor = Color.blue;
        Color defaultColor = Color.white;

        foreach (Button button in new Button[] { button100, button70, button40, button10 })
        {
            if (button == selected)
            {
                button.image.color = selectedColor;
            }
            else
            {
                button.image.color = defaultColor;
            }
        }
    }
}