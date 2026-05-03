using System.Collections;
using UnityEngine;

public class Fadesystem
{
    public static IEnumerator FadeIn(CanvasGroup group, float duration)
    {
        float time = 0;
        group.alpha = 0;

        while (time < duration)
        {
            time += Time.deltaTime;
            group.alpha = time / duration;
            yield return null;
        }

        group.alpha = 1;
    }

    public static IEnumerator FadeOut(CanvasGroup group, float duration)
    {
        float time = 0;
        group.alpha = 1;

        while (time < duration)
        {
            time += Time.deltaTime;
            group.alpha = 1 - (time / duration);
            yield return null;
        }

        group.alpha = 0;
    }
}
