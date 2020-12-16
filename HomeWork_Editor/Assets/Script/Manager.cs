using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Manager : MonoBehaviour
{
    public static Manager Instance { get { return instance; } }
    static Manager instance;

    public Text scoreUI;
    public Text timeUI;

    [SerializeField]
    int score = 0;
    [SerializeField]
    GameObject enemy;
    [SerializeField]
    int maxEnemy = 10;
    float time;
    public Transform enemyTrans;
    public float enemyRespawn;

    public void Awake()
    {
        instance = this;
        ResetAll();
    }

    public void Start()
    {
        StartCoroutine(EnemyRespawn());
    }
    public void Update()
    {
        time += Time.deltaTime;
        timeUI.text = string.Format("Time : {0}", time);
    }
    IEnumerator EnemyRespawn()
    {
        while (true)
        {

            if (enemyTrans.childCount < maxEnemy)
            {
                yield return new WaitForSeconds(enemyRespawn);
                var cloneEnemy = Instantiate(enemy);
                cloneEnemy.transform.parent = enemyTrans;

                float randomX = Random.Range(-13.5f, 13.5f);
                float randomY = Random.Range(0.5f, 5f);
                float randomZ = Random.Range(-13.5f, 13.5f);

                cloneEnemy.transform.position = new Vector3(randomX, randomY, randomZ);
                cloneEnemy.GetComponent<Enemy>().DestroyTicTock();
            }
            else
                yield return null;
        }
    }

    public void AddScore(int _score)
    {
        score += _score;
        scoreUI.text = string.Format("Score : {0}", score);
    }

    public void ResetAll()
    {
        score = 0;
        time = 0;
        scoreUI.text = string.Format("Score : {0}", score);
    }

    public void SetMaxEnemy(int _maxEnemy)    {        maxEnemy = _maxEnemy;    }
    public int GetMaxEnemy() { return maxEnemy; }
    public GameObject GetEnemyPrefab() { return enemy; }
    public void SetRespawnTick(float _tick) { enemyRespawn = _tick; }
    public float GetRespawnTick() { return enemyRespawn; }
}
