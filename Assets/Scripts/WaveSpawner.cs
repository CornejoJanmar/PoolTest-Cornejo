using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveSpawner : MonoBehaviour
{

    [SerializeField] float timeToSpawn = 5f;
    [SerializeField] float timeSinceSpawn;
    [SerializeField] List<GameObject> enemyList;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] int enemyAmount;
    [SerializeField] Transform enemySpawnpoint;
    [SerializeField] TMP_Text text;
    public int enemyCount = 30;

    private void Start()
    {
        enemyList = new List<GameObject>();

        for (int i = 0; i < enemyAmount; i++)
        {
            GameObject objBullet = (GameObject)Instantiate(enemyPrefab);
            objBullet.SetActive(false);
            enemyList.Add(objBullet);
        }
    }

    private void Update()
    {
        text.text = "Enemy Count : " + enemyCount;
        timeSinceSpawn += Time.deltaTime;
        if(timeSinceSpawn >= timeToSpawn)
        {
            if(enemyCount > 0)
            {
                StartCoroutine(spawnEnemy(timeToSpawn));
                timeSinceSpawn = 0f;
            }
        }
    }

    public void _enemyCount(int amount)
    {
        enemyCount -= amount;
    }

    IEnumerator spawnEnemy(float interval)
    {        
        for (int i = 0; i < enemyList.Count; i++)
        {
            if (!enemyList[i].activeInHierarchy)
            {
                yield return new WaitForSeconds(interval);
                enemyList[i].transform.position = enemySpawnpoint.position;
                enemyList[i].SetActive(true);
            }
        }
        StartCoroutine(spawnEnemy(interval));
    }

}
