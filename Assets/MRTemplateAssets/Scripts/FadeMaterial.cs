using System.Collections;
using UnityEngine;

public class FadeMaterial : MonoBehaviour
{
    // attached game object for fading
    public GameObject Environment;
    public GameObject Table;
    public GameObject Chair;
    public GameObject Ball;

    // fade speed length
    public float fadeSpeed;

    Coroutine m_FadeCoroutine;

    public void FadeSkybox(bool visible)
    {
        if (m_FadeCoroutine != null)
            StopCoroutine(m_FadeCoroutine);

        m_FadeCoroutine = StartCoroutine(Fade(visible));
    }

    //Fade Coroutine
    public IEnumerator Fade(bool visible)
    {
        Renderer rend = Environment.transform.GetComponent<Renderer>();
        float alphaValue = rend.material.GetFloat("_Alpha");

        if (visible)
        {
            //while loop to deincrement Alpha value until object is invisible
            while (rend.material.GetFloat("_Alpha") > 0f)
            {
                alphaValue -= Time.deltaTime / fadeSpeed;
                rend.material.SetFloat("_Alpha", alphaValue);
                yield return null;
            }
            rend.material.SetFloat("_Alpha", 0f);
            Table.SetActive(false);
            Chair.SetActive(false);
            Ball.SetActive(false);
        }
        else if (!visible)
        {
            //while loop to increment object Alpha value until object is opaque
            while (rend.material.GetFloat("_Alpha") < 1f)
            {
                alphaValue += Time.deltaTime / fadeSpeed;
                rend.material.SetFloat("_Alpha", alphaValue);
                yield return null;
            }
            rend.material.SetFloat("_Alpha", 1f);
            Table.SetActive(true);
            Chair.SetActive(true);
            Ball.SetActive(true);
        }
    }
}
