using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_playbutton : MonoBehaviour
{
    public Vector3 scale1 = new Vector3(1, 1, 1);
    public Vector3 scale2 = new Vector3(0.9f, 0.9f, 0.9f);
    public float duration = 0.5f;

    void Start()
    {
        StartCoroutine(ScaleLoopCoroutine());
    }

    IEnumerator ScaleLoopCoroutine()
    {
        while (true)
        {
            // scale1からscale2へ
            yield return ScaleTo(scale2, duration / 2);
            // scale2からscale1へ
            yield return ScaleTo(scale1, duration / 2);
        }
    }

    IEnumerator ScaleTo(Vector3 targetScale, float duration)
    {
        Vector3 startScale = transform.localScale;
        float time = 0;

        while (time < duration)
        {
            transform.localScale = Vector3.Lerp(startScale, targetScale, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        transform.localScale = targetScale;
    }
}
