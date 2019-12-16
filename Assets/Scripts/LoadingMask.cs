using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LoadingMask : MonoBehaviour
{
    public bool loaded;
    private float transparency;
    private CanvasGroup thisAlpha;
    // Start is called before the first frame update
    void Start()
    {
        thisAlpha = GetComponent<CanvasGroup>();
        transparency = thisAlpha.alpha;
        if (!loaded)
            StartCoroutine(ActivateMask());
        else
            StartCoroutine(DeactivateMask());
    }

    public void Loading()
    {
        StartCoroutine(ActivateMask());
    }

    public void Loaded()
    {
        StartCoroutine(DeactivateMask());
    }
    IEnumerator ActivateMask()
    {
        while (transparency < 1f)
        {
            yield return new WaitForSeconds(0.001f);
            transparency += 0.1f;
            GetComponent<CanvasGroup>().alpha = transparency;
        }
        StopCoroutine(ActivateMask());
    }

    IEnumerator DeactivateMask()
    {
        while (transparency > 0.0f)
        {
            transparency -= 0.1f;
            yield return new WaitForSeconds(0.01f);
            GetComponent<CanvasGroup>().alpha = transparency;
        }
        this.gameObject.SetActive(false);
        StopCoroutine(DeactivateMask());
    }
}
