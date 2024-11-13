using UnityEngine;

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


    public float GetDamage()
    {
        float baseDamage = Stats.AttackPower;

        bool isCritical = UnityEngine.Random.value < Stats.CriticalChance;

        float finalDamage = isCritical ? baseDamage * (1 + Stats.CriticalDamagePercentage / 100) : baseDamage;
        return finalDamage;
    }


    public void ApplyLevelUpStats()
    {
        float level = GameManager.Instance.Player.LevelSystem.Level;

        // 레벨에 따른 스탯 증가
        Stats.AttackPower += level * Define.ATTACK_POWER_INCREASE_RATE;
        Stats.DefensePower += level * Define.DEFENSE_POWER_INCREASE_RATE;
        Stats.CriticalDamagePercentage += level * Define.CRITICAL_DAMAGE_INCREASE_RATE;
        Stats.CriticalChance += level * Define.CRITICAL_CHANCE_INCREASE_RATE;
    }

    public void AdjustStatsForEquipment(Item item, bool isEquipping)
    {
        int modifier = isEquipping ? 1 : -1;

        switch (item.data.type)
        {
            case Define.ItemType.Weapon:
                Stats.AttackPower += item.data.stat * item.level * modifier;
                break;

            case Define.ItemType.Armor:
                Stats.DefensePower += item.data.stat * item.level * modifier;
                break;
        }

        Debug.Log("공격력 증가" + Stats.AttackPower);
    }
}