using System;
using System.Collections;
using UnityEngine;

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
            Save();
        }
    }
}