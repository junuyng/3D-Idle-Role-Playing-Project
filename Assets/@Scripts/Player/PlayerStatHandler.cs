




public class PlayerStatHandler
{
    private PlayerSO data;


    public PlayerStats Stats { get; private set; }

    public PlayerStatHandler(PlayerSO _data)
    {
        data = _data;
        Stats = new PlayerStats(); 
        InitialStat();
    }


    private void InitialStat()
    {
        //기본 데이터
        Stats.MaxHP = data.Data.MaxHP;
        //전투 데이터
        Stats.AttackPower = data.CombatData.AttackPower;
        Stats.DefensePower = data.CombatData.DefensePower;
        Stats.CriticalDamagePercentage = data.CombatData.CriticalDamagePercentage;
        Stats.CriticalChance = data.CombatData.CriticalChance;
        //움직임 데이터
        Stats.RotationSpeed = data.MovementData.RotationSpeed;
        Stats.MoveSpeed = data.MovementData.MoveSpeed;
        Stats.RunSpeed = data.MovementData.RunSpeed;
        Stats.JumpForce = data.JumpData.JumpForce;
        //경험치 관련 데이터
        Stats.Level = data.ExperienceData.Level;
        Stats.RequiredEXP = data.ExperienceData.RequiredEXP;
        Stats.CurEXP = data.ExperienceData.CurEXP;
        Stats.ExperienceGain = data.ExperienceData.ExperienceGain;
    }

 


    private void CacheStatsFromData(PlayerStats stats)
    {
    }
}