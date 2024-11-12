using System;
using UnityEngine;
using UnityEngine.Serialization;

// 변동되는 스탯인 경우에는 따로 StatHandler를 통해 다룰 것 
[CreateAssetMenu(fileName = "Creature", menuName = "Creature")]
public class CreatureSO : ScriptableObject
{
    [SerializeField] private BaseData data;

    [FormerlySerializedAs("attackData")] [SerializeField]
    private CombatData combatData;

    [SerializeField] private MovementData movementData;

    public BaseData Data => data;
    public CombatData CombatData => combatData;
    public MovementData MovementData => movementData;
}

[Serializable]
public class BaseData
{
    [field: SerializeField] public float MaxHP { get; private set; }
}


[Serializable]
public class CombatData
{
    [field: SerializeField] public float AttackPower { get; private set; } // 공격력 수치
    [field: SerializeField] public float DefensePower { get; private set; } // 방어력 수치
    [field: SerializeField] public float CriticalDamagePercentage { get; private set; } // 치명타 시 추가 데미지 퍼센트(%)
    [field: SerializeField] public float CriticalChance { get; private set; } // 치명타 발생 확률(%)
}


[Serializable]
public class MovementData
{
    [field: SerializeField] public float RotationSpeed { get; private set; }
    [field: SerializeField] public float MoveSpeed { get; private set; }
    [field: SerializeField] public float RunSpeed { get; private set; }
}