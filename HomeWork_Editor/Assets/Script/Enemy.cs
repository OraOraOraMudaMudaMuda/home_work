using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    int score;
    [SerializeField]
    float destroyTime = 3f;
    [SerializeField]
    GameObject effect;

    public void DestroyTicTock()
    {
        StartCoroutine(DestroyCoroutain());
    }

    IEnumerator DestroyCoroutain()
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(gameObject);
    }

    public void PlayerHitEnemy()
    {
        Manager.Instance.AddScore(score);
        var cloneEffect = Instantiate(effect);
        cloneEffect.transform.position = transform.position;
        cloneEffect.GetComponent<Effect>().EffectOn();
        StopAllCoroutines();
        Destroy(gameObject);
    }
    public void SetScore(int _score) { score = _score; }
    public int GetScore() { return score; }

    public void SetDestroyTime(float _destroyTime) { destroyTime = _destroyTime; }
    public float GetDestroyTime() { return destroyTime; }
}
