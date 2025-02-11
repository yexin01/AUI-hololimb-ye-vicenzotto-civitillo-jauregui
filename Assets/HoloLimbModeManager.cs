using UnityEngine;
using UnityEngine.Events;
using Oculus.Movement.Effects;
using Oculus.Movement.AnimationRigging;

public class HoloLimbModeManager : MonoBehaviour
{
    [Header("Components to Control")]
    public RetargetingLayer retargetingLayer;  
    public OVRSkeleton ovrSkeleton;            

    [Header("Mirrored Object")]
    public LateMirroredObject lateMirroredObject;

    [Header("Mode Events")]
    public UnityEvent OnStaticModeEnabled;
    public UnityEvent OnDynamicModeEnabled;

    [Header("UI Elements")]
    public GameObject buttonBackgroundStatic; // Assegna il riferimento nel Inspector
    public GameObject buttonBackgroundMirror; // Assegna il riferimento nel Inspector

    public bool isStaticMode { get; private set; } = false;

    private void Start()
    {
        // Assicuriamoci che la UI sia impostata correttamente all'avvio
        UpdateMenuUI();
    }

    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            ToggleMode();
        }
    }

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

    public void SetStaticMode()
    {
        if (lateMirroredObject != null)
        {
            lateMirroredObject.enabled = false;  
        }

        isStaticMode = true;
        OnStaticModeEnabled?.Invoke();
        Debug.Log("Static Mode enabled: the mirrored object is frozen.");

        // Aggiorna la UI
        UpdateMenuUI();
    }

    public void SetDynamicMode()
    {
        if (lateMirroredObject != null)
        {
            lateMirroredObject.enabled = true;  
        }

        isStaticMode = false;
        OnDynamicModeEnabled?.Invoke();
        Debug.Log("Dynamic Mode enabled: the mirrored object updates with tracking.");

        // Aggiorna la UI
        UpdateMenuUI();
    }

    private void UpdateMenuUI()
    {
        if (buttonBackgroundStatic != null && buttonBackgroundMirror != null)
        {
            buttonBackgroundStatic.SetActive(isStaticMode);
            buttonBackgroundMirror.SetActive(!isStaticMode);
        }
    }
}
