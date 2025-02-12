using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject menu;
    public float offsetDistance = 0.5f; // distanza da spostare
    public void MoveMenuToDynamicRightPosition()
{
    if (menu != null)
    {
        // Calcola la nuova posizione rispetto alla fotocamera principale
        Vector3 cameraPos = Camera.main.transform.position;
        Vector3 rightDirection = Camera.main.transform.right; // Usa la direzione destra della fotocamera
        Vector3 newPos = cameraPos + rightDirection * offsetDistance;
        menu.transform.position = newPos;

        // Allinea la rotazione del menu con la fotocamera
        menu.transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward, Vector3.up);
    }
}

    public void DeactivateLazyFollow()
    {
        LazyFollow lazyFollow = menu.GetComponent<LazyFollow>();
        if (lazyFollow != null)
        {
            lazyFollow.enabled = false;
        }
    }
}