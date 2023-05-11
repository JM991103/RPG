using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coroutuneTest : MonoBehaviour
{
    public MeshRenderer render;

    private void Start()
    {
        
    }

    void FadeOut()
    {
        Color c = render.material.color;

        for (float f = 1f; f >= 0; f -= 0.1f)
        {
            c.a = f;
            render.material.color = c;
        }
    }

    IEnumerator FadeOutCo()
    {

        for (float f = 1f; f >= 0; f -= 0.1f)
        {
            Color c = render.material.color;
            c.a = f;
            render.material.color = c;
            yield return null;
        }
    }
}
