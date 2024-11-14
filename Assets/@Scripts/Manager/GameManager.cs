using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public Player Player { get; set; }
    public CurrencyManager currencyManager;

    public int MaxStageLevel { get; set; } = 1;
    public int CurrentStage { get; set; }

    protected override void Awake()
    {
        base.Awake();
        LoadCurrencyData();
    }

    protected void Start()
    {
        StartCoroutine(AutoSaveCoroutine());
    }

    public void InitializePlayerReference()
    {
        Player = GameObject.Find("Player").GetComponent<Player>();
        LoadPlayerData();
    }


    [ContextMenu("저장")]
    public void Save()
    {
        GameData gameData = new GameData(Player, MaxStageLevel, currencyManager);
        DataManager.SaveData(gameData);
    }


    public void LoadPlayerData()
    {
        GameData gameData = DataManager.LoadData<GameData>();

        if (gameData == null)
            Player.Initialize(null);
        else
            Player.Initialize(gameData.playerData);
    }


    public void LoadCurrencyData()
    {
        GameData gameData = DataManager.LoadData<GameData>();

        if (gameData == null)
        {
            MaxStageLevel = 1;
            currencyManager = new CurrencyManager(0);
            return;
        }

        MaxStageLevel = gameData.stageLevel;
        currencyManager = new CurrencyManager(gameData.Gold);
    }


    [ContextMenu("데이터 삭제")]
    public void DeleteData()
    {
        DataManager.DeleteData<GameData>();
    }

    private IEnumerator AutoSaveCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Define.AUTO_SAVE_INTERVAL);

            //TODO 플레이어 프리펩에 정보를 들고 있지 않고 따로 관리하도록 하기
            //임시적으로 게임씬에서만 저장하게 함
            if (SceneManager.GetActiveScene().name == Define.SceneType.GameScene.ToString())
                Save();
        }
    }
}