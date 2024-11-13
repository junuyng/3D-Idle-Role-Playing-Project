using System;
using UnityEngine; // [SerializeField]를 위해 필요

[Serializable]
public class PlayerStats
{
    // 스탯 값에 영향을 직접적으로 주지 않고 다루기 위한 데이터
    [SerializeField] public float StatModifier;

    // 변동 가능한 데이터 영역
    [SerializeField] public float MaxHP;
    [SerializeField] public float AttackPower;
    [SerializeField] public float DefensePower;
    [SerializeField] public float CriticalDamagePercentage; // 치명타 시 추가 데미지 퍼센트(%)
    [SerializeField] public float CriticalChance; // 치명타 발생 확률(%)
    [SerializeField] public float RotationSpeed;
    [SerializeField] public float MoveSpeed;
    [SerializeField] public float RunSpeed;
    [SerializeField] public int Level;
    [SerializeField] public float RequiredEXP;
    [SerializeField] public float CurEXP;
    [SerializeField] public int ExperienceGain;
    [SerializeField] public float JumpForce;
}