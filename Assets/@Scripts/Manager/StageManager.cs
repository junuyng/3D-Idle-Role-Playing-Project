using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class StageManager : MonoBehaviour
{
    //enemy 소환이  더 많아질 것 같으면  pool 사용 방식도 고려 해봐야 함
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private GameObject[] bossPrefabs;
    [SerializeField] private GameObject[] floor;
    [SerializeField] private GameObject playerPrefab;

    private int stageLevel;
    private List<GameObject> enemies = new List<GameObject>();

    private GameObject bossEnemy;

    private void Awake()
    {
        stageLevel = GameManager.Instance.CurrentStage;
        EnemyGeneratorByStageLevel();
        MapGeneratorByStageLevel(); 
        GameObject player =  Instantiate(playerPrefab) ;
        player.name = Utils.RemoveCloneFormat(player.name);
        GameManager.Instance.InitializePlayerReference();
    }

    
    
    private void Start()
    {
        StartCoroutine(SpawnEnemiesOverTime());
    }
    

    //TODO 무한 맵으로 변경  
    private void MapGeneratorByStageLevel()
    {
        //임의로 10개 설치하도록 
        for (int i = 0; i < 10; i++)
        {
            Instantiate(floor[stageLevel], transform.position + Vector3.forward * i * 10, quaternion.identity,
                transform);
        }
    }


    private void EnemyGeneratorByStageLevel()
    {
        for (int i = 0; i < Define.DefaultEnemySpawnCount; i++)
        {
            GameObject newEnemy = Instantiate(enemyPrefabs[stageLevel], transform);
            newEnemy.GetComponent<HealthSystem>().OnDeathEvent += RemoveEnemy;
            enemies.Add(newEnemy);
            newEnemy.SetActive(false);
        }

        bossEnemy = Instantiate(bossPrefabs[stageLevel], transform);
        bossEnemy.GetComponent<HealthSystem>().OnDeathEvent += OnStageClear;
        bossEnemy.SetActive(false);
    }


    private void RemoveEnemy(GameObject enemy)
    {
        enemies.Remove(enemy);
    }

    private void OnStageClear(GameObject bossEnemy)
    {
         GameManager.Instance.MaxStageLevel++;
         GameManager.Instance.Save();
         SceneManager.LoadScene(Define.SceneType.LobbyScene.ToString());
    }

    private IEnumerator SpawnEnemiesOverTime()
    {
        while (enemies.Count > 0)
        {
            yield return new WaitForSeconds(3f);

            for (int i = 0; i < enemies.Count; i++)
            {
                var enemy = enemies[i];
                if (!enemy.activeSelf)
                {
                    enemy.transform.position = GameManager.Instance.Player.transform.position +
                                               new Vector3(Random.Range(-1f, 1f), 1, 15f);
                    enemy.SetActive(true);
                    break;
                }
            }
        }

        SpawnBossEnemy();
    }


    private void SpawnBossEnemy()
    {
        bossEnemy.transform.position = GameManager.Instance.Player.transform.position +
                                      new Vector3(Random.Range(-1f, 1f), 1, 15f);
        bossEnemy.SetActive(true);
        Debug.Log("보스 등장!! ");
    }



}