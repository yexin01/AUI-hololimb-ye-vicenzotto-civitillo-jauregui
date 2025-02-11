using UnityEngine;
using UnityEngine.Events;
using Oculus.Movement.Effects;
using Oculus.Movement.AnimationRigging;  // Per accedere a LateMirroredObject

public class HoloLimbModeManager : MonoBehaviour
{
    [Header("Components to Control")]
    public RetargetingLayer retargetingLayer;  // Il componente che gestisce il mapping dinamico
    public OVRSkeleton ovrSkeleton;            // Il componente che aggiorna i bone

    [Header("Mirrored Object")]
    public LateMirroredObject lateMirroredObject;  // Riferimento allo script del mirrored object

    [Header("Mode Events")]
    public UnityEvent OnStaticModeEnabled;
    public UnityEvent OnDynamicModeEnabled;

    // Flag per indicare la modalità corrente: true se in modalità statica (mirrored object congelato)
    public bool isStaticMode { get; private set; } = false;

    // Esempio: in Update ascoltiamo l'input del trigger per alternare la modalità.
    private void Update()
    {
        // Se l'utente preme il trigger del controller (ad esempio, PrimaryIndexTrigger), toggla la modalità.
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            ToggleMode();
        }
    }

    /// <summary>
    /// Alterna la modalità: se è attiva la modalità statica, passa a quella dinamica, e viceversa.
    /// </summary>
    public void ToggleMode()
    {
        if (isStaticMode)
        {
            SetDynamicMode();
        }
        else
        {
            SetStaticMode();
        }
    }

    /// <summary>
    /// Imposta la modalità statica: il mirrored object viene congelato (lo script viene disattivato),
    /// mentre il tracking dell'oggetto originale continua normalmente.
    /// </summary>
    public void SetStaticMode()
    {
        if (lateMirroredObject != null)
        {
            lateMirroredObject.enabled = false;  // Disattiva gli update del mirrored object
        }

        // Non disabilitiamo retargetingLayer e ovrSkeleton, in modo che il tracking continui.
        isStaticMode = true;
        OnStaticModeEnabled?.Invoke();
        Debug.Log("Static Mode enabled: the mirrored object is frozen.");
    }

    /// <summary>
    /// Imposta la modalità dinamica: il mirrored object riprende ad aggiornarsi,
    /// seguendo il tracking dell'oggetto originale.
    /// </summary>
    public void SetDynamicMode()
    {
        if (lateMirroredObject != null)
        {
            lateMirroredObject.enabled = true;  // Riattiva gli update del mirrored object
        }

        isStaticMode = false;
        OnDynamicModeEnabled?.Invoke();
        Debug.Log("Dynamic Mode enabled: the mirrored object updates with tracking.");
    }
}