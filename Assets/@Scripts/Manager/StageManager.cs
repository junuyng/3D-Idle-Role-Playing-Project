using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

public class StageManager : MonoBehaviour
{
    //enemyPrefab가 더 많아질 것 같으면 pool 사용
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private GameObject[] floor;

    public int StageLevel { get; set; } = 1;
    private List<GameObject> enemies = new List<GameObject>();


    private void Awake()
    {
        EnemyGeneratorByLevel();
        MapGeneratorByLevel();
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemiesOverTime());
    }


    //선택한 stage Level애 따라 stage 생성


    //Player 생성

    //stage Level에 맞는 몬스터 지정 


    //코루틴을 통해 몬스터 배치 - 무한맵하고 추후 연계


    //TODO 무한 맵으로 변경  
    private void MapGeneratorByLevel()
    {
        //임의로 10개 설치하도록 
        for (int i = 0; i < 10; i++)
        {
            Instantiate(floor[StageLevel - 1], transform.position + Vector3.forward * i * 10, quaternion.identity,
                transform);
        }
    }


    private void EnemyGeneratorByLevel()
    {
        for (int i = 0; i < Define.DefaultEnemySpawnCount; i++)
        {
            GameObject newEnemy = Instantiate(enemyPrefabs[StageLevel], transform);
            newEnemy.GetComponent<HealthSystem>().OnDeathEvent += RemoveEnemy;
            enemies.Add(newEnemy);
            newEnemy.SetActive(false);
        }
    }


    private void RemoveEnemy(GameObject enemy)
    {
        enemies.Remove(enemy);
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
        
        Debug.Log("보스 등장!! ");
    }
    
    
}