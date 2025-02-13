using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject menu;
    public float offsetDistance = 0.5f; // distanza da spostare

    public void MoveMenuToDynamicRightPosition()
    {
        if (menu != null)
        {
            // Ottieni il nome della scena attiva
            string sceneName = SceneManager.GetActiveScene().name;

            // Calcola la posizione della fotocamera e la direzione destra
            Vector3 cameraPos = Camera.main.transform.position;
            Vector3 rightDirection = Camera.main.transform.right;
            Vector3 newPos;

            // Logica condizionale in base al nome della scena
            if (sceneName == "LeftArmScene")
            {
                // Se siamo in LeftArmScene, spostiamo il menu verso destra
                newPos = cameraPos + rightDirection * offsetDistance;
                // Ruota il menu di 90 gradi in senso positivo sull'asse Y
                menu.transform.rotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y + 90, 0);
            }
            else if (sceneName == "RightArmScene")
            {
                // Se siamo in RightArmScene, il codice rimane invariato
                newPos = cameraPos - rightDirection * offsetDistance;
                // Ruota il menu di 90 gradi in senso negativo sull'asse Y
                menu.transform.rotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y - 90, 0);
            }
            else
            {
                // Se la scena non è né "LeftArmScene" né "RightArmScene", si applica il comportamento di default (come in RightArmScene)
                newPos = cameraPos - rightDirection * offsetDistance;
                menu.transform.rotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y - 90, 0);
            }

            // Applica la nuova posizione al menu
            menu.transform.position = newPos;
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
