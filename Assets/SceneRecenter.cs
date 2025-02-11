using UnityEngine;

public class AutoRecenterOnStart : MonoBehaviour
{
    void Start()
    {
        // Trigger recenter as soon as the scene starts
        OVRManager.display.RecenterPose();
        Debug.Log("Recenter triggered on scene start!");
    }
}
