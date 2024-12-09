using UnityEngine;

public class MenuOffset : MonoBehaviour
{
    public Transform handAnchor; // Riferimento al Left Hand Tracked Anchor
    public Vector3 offset = new Vector3(0f, 0.1f, 0.1f); // Offset sopra il palmo

    void Update()
    {
        if (handAnchor != null)
        {
            // Aggiorna posizione e rotazione ogni frame
            transform.position = handAnchor.position + handAnchor.rotation * offset;
            transform.rotation = handAnchor.rotation;
        }
        else
        {
            Debug.LogWarning("handAnchor is not assigned or is null!");
        }
    }
}