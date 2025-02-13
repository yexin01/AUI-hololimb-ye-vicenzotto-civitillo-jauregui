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
            Vector3 newPos = cameraPos - rightDirection * offsetDistance;
            menu.transform.position = newPos;

            // Ruota il menu di 90 gradi sull'asse Y
            menu.transform.rotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y - 90, 0);
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

        public void ActivateLazyFollow()
    {
        LazyFollow lazyFollow = menu.GetComponent<LazyFollow>();
        if (lazyFollow != null)
        {
            lazyFollow.enabled = true;
        }
    }
}