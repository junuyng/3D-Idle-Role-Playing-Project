using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public Player Player { get; set; }
    public CurrencyManager currencyManager;

    public int StageLevel { get; set; } = 1;


    protected override void Awake()
    {
        base.Awake();
        LoadCurrencyData();
    }


    public void InitializePlayerReference()
    {
        Player = GameObject.Find("Player").GetComponent<Player>();
        LoadPlayerData();
    }


    [ContextMenu("저장")]
    public void Save()
    {
        GameData gameData = new GameData(Player, StageLevel, currencyManager);
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
            StageLevel = 1;
            currencyManager = new CurrencyManager(0);
            return;
        }

        StageLevel = gameData.stageLevel;
        currencyManager = new CurrencyManager(gameData.Gold);
    }


    [ContextMenu("데이터 삭제")]
    public void DeleteData()
    {
        DataManager.DeleteData<GameData>();
    }
}