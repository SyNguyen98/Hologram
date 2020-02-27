using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class KiraKira : MonoBehaviour {

    public RawImage[] rawImage;
    int starNum = 14;

	// Use this for initialization
	void Start () {
        for (int i = 0; i < 14; i++)
        {
            rawImage[i].canvasRenderer.SetAlpha(0.0f);
        }
    }

    IEnumerator IFadeIn()
    {
        for (int i = 0; i < 14; i += 3)
        {
            rawImage[i].CrossFadeAlpha(1, 0.3f, false);
        }
        yield return new WaitForSeconds(0.1f);
        for (int i = 2; i < 14; i += 3)
        {
            rawImage[i].CrossFadeAlpha(1, 0.3f, false);
        }
        yield return new WaitForSeconds(0.1f);
        for (int i = 1; i < 14; i += 3)
        {
            rawImage[i].CrossFadeAlpha(1, 0.3f, false);
        }
    }

    IEnumerator IFadeOut()
    {
        for (int i = 0; i < 14; i += 3)
        {
            rawImage[i].CrossFadeAlpha(0, 0.3f, false);
        }
        yield return new WaitForSeconds(0.1f);
        for (int i = 2; i < 14; i += 3)
        {
            rawImage[i].CrossFadeAlpha(0, 0.3f, false);
        }
        yield return new WaitForSeconds(0.1f);
        for (int i = 1; i < 14; i += 3)
        {
            rawImage[i].CrossFadeAlpha(0, 0.3f, false);
        }     
    }

    public void FadeIn()
    {
        StartCoroutine(IFadeIn());
    }

    public void FadeOut()
    {
        StartCoroutine(IFadeOut());
    }
}
