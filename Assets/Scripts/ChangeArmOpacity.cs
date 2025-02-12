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
            ArmMaterial.SetFloat("_Surface", 0); // 0 = Opaque, 1 = Transparent
            ArmMaterial.renderQueue = (int)UnityEngine.Rendering.RenderQueue.Geometry;
            ArmMaterial.SetShaderPassEnabled("Transparent", false);
            ArmMaterial.SetShaderPassEnabled("ShadowCaster", true);
            ArmMaterial.SetFloat("_SrcBlend", (float)UnityEngine.Rendering.BlendMode.One);
            ArmMaterial.SetFloat("_DstBlend", (float)UnityEngine.Rendering.BlendMode.Zero);
            ArmMaterial.SetFloat("_ZWrite", 1);

            // Ensure the changes apply immediately
            ArmMaterial.EnableKeyword("_SURFACE_TYPE_OPAQUE");
            ArmMaterial.DisableKeyword("_SURFACE_TYPE_TRANSPARENT");
            UpdateButtonVisuals(button100);
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
            ArmMaterial.SetFloat("_Surface", 1); // 1 = Transparent
            ArmMaterial.renderQueue = (int)UnityEngine.Rendering.RenderQueue.Transparent;
            ArmMaterial.SetShaderPassEnabled("Transparent", true);
            ArmMaterial.SetShaderPassEnabled("ShadowCaster", false);
            ArmMaterial.SetFloat("_SrcBlend", (float)UnityEngine.Rendering.BlendMode.SrcAlpha);
            ArmMaterial.SetFloat("_DstBlend", (float)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            ArmMaterial.SetFloat("_ZWrite", 0);

            ArmMaterial.EnableKeyword("_SURFACE_TYPE_TRANSPARENT");
            ArmMaterial.DisableKeyword("_SURFACE_TYPE_OPAQUE");

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
            ArmMaterial.SetFloat("_Surface", 1); // 1 = Transparent
            ArmMaterial.renderQueue = (int)UnityEngine.Rendering.RenderQueue.Transparent;
            ArmMaterial.SetShaderPassEnabled("Transparent", true);
            ArmMaterial.SetShaderPassEnabled("ShadowCaster", false);
            ArmMaterial.SetFloat("_SrcBlend", (float)UnityEngine.Rendering.BlendMode.SrcAlpha);
            ArmMaterial.SetFloat("_DstBlend", (float)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            ArmMaterial.SetFloat("_ZWrite", 0);

            ArmMaterial.EnableKeyword("_SURFACE_TYPE_TRANSPARENT");
            ArmMaterial.DisableKeyword("_SURFACE_TYPE_OPAQUE");

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
            ArmMaterial.SetFloat("_Surface", 1); // 1 = Transparent
            ArmMaterial.renderQueue = (int)UnityEngine.Rendering.RenderQueue.Transparent;
            ArmMaterial.SetShaderPassEnabled("Transparent", true);
            ArmMaterial.SetShaderPassEnabled("ShadowCaster", false);
            ArmMaterial.SetFloat("_SrcBlend", (float)UnityEngine.Rendering.BlendMode.SrcAlpha);
            ArmMaterial.SetFloat("_DstBlend", (float)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            ArmMaterial.SetFloat("_ZWrite", 0);

            ArmMaterial.EnableKeyword("_SURFACE_TYPE_TRANSPARENT");
            ArmMaterial.DisableKeyword("_SURFACE_TYPE_OPAQUE");

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