using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetEmission : MonoBehaviour
{
    public SkinnedMeshRenderer render;
    Material material;

    bool isAttack = false;
    public float duration = 1.0f;
    float timeLeft = 0;

    private void Start()
    {
        material = render.material;
    }

    public void FX()
    {
        Debug.Log("FX time");
        isAttack = true;
        material.EnableKeyword("_EMISSION");
    }

    private void Update()
    {
        if (isAttack)
        {
            if (timeLeft < duration)
            {
                timeLeft += Time.deltaTime;
            }
            else
            {
                material.DisableKeyword("_EMISSION");
                isAttack = false;
            }            
        }
    }
}
