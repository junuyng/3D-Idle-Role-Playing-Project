using System;
using UnityEngine;

public class LevelSystem
{
    public int Level { get;  set; } = 1;
    public float RequiredExp { get; private set; }
    public float CurExp { get; private set; }

    public event Action OnLevelUpEvent;
    public event Action<float> OnChangeExpEvent;

    private PlayerStatHandler statHandler;

    public LevelSystem(PlayerStatHandler _statHandler)
    {
        statHandler = _statHandler;
        CurExp = _statHandler.Stats.CurEXP;
        RequiredExp = _statHandler.Stats.RequiredEXP;
    }


    public void AddExp(float amount)
    {
        CurExp += amount;
        OnChangeExpEvent?.Invoke(CurExp / RequiredExp);
        TryLevelUp();
    }


    private void TryLevelUp()
    {        Debug.Log($"exp {CurExp} / requiredExp {RequiredExp}");

        if (CurExp >= RequiredExp)
        {
            CurExp -= RequiredExp;
            statHandler.Stats.CurEXP = CurExp;
            
            RequiredExp = Define.EXP_BASE_GAIN * Level;
            statHandler.Stats.RequiredEXP = RequiredExp;
            Level++;
            OnLevelUpEvent?.Invoke();
        }

        statHandler.ApplyLevelUpStats();
        OnChangeExpEvent?.Invoke(CurExp / RequiredExp);
    }
}