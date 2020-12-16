using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    float destroyTime = 1.5f;
    
    public void EffectOn()
    {
        StartCoroutine(DestroyCoroutain());
    }

    IEnumerator DestroyCoroutain()
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(gameObject);
    }
}
