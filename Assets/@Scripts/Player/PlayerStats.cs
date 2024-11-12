using System;

[Serializable]
public class PlayerStats
{
    
    //스탯 값에 영향을 직접적으로 주지 않고 다루기 위한 데이터
    public float StatModifier { get; set; }

    
    //변동 가능한 데이터 영역 
    public float MaxHP { get;  set; }
    public float AttackPower { get;  set; } 
    public float DefensePower { get;  set; } 
    public float CriticalDamagePercentage { get;  set; } // 치명타 시 추가 데미지 퍼센트(%)
    public float CriticalChance { get;  set; } // 치명타 발생 확률(%)
    public float RotationSpeed { get;  set; }
    public float MoveSpeed { get;  set; }
    public float RunSpeed { get;  set; }
    public int Level { get;  set; }
    public float RequiredEXP { get;  set; }
    public float CurEXP { get;  set; }
    public int ExperienceGain { get;  set; }
    public float JumpForce { get;  set; }
}