using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameData
{
    public PlayerData playerData = new PlayerData();

    public int stageLevel;
    public int Gold;

    public GameData(Player _player, int _stageLevel, CurrencyManager _currencyManager)
    {
        playerData.stats = _player.statHandler.Stats;
        playerData.level = _player.LevelSystem.Level;

        stageLevel = _stageLevel;
        Gold = _currencyManager.Gold;
    }
}



[Serializable]
public class PlayerData
{
    public PlayerStats stats;
    public int level;
}