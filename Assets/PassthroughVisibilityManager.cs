using UnityEngine;
using UnityEngine.XR.Management; // Necessario per XR Plugin Management

public class XROpenXR_PassthroughManager : MonoBehaviour
{
    public GameObject[] vrObjects; // Tavoli o altri oggetti da nascondere
    private bool isPassthroughActive = false;

    void Update()
    {
        // Controlla se XR Display Subsystem è attivo (indica modalità VR)
        var xrDisplaySubsystem = XRGeneralSettings.Instance?.Manager?.activeLoader?.GetLoadedSubsystem<UnityEngine.XR.XRDisplaySubsystem>();

        if (xrDisplaySubsystem != null)
        {
            isPassthroughActive = !xrDisplaySubsystem.running; // Se il display non è in modalità VR, assume che sia in passthrough
        }

        // Nasconde gli oggetti se il passthrough è attivo
        foreach (GameObject obj in vrObjects)
        {
            obj.SetActive(!isPassthroughActive);
        }
    }
}
