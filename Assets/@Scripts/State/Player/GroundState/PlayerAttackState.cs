using UnityEngine;

public class PlayerAttackState : PlayerGroundState
{
    private float attackStartTime;
    private bool weaponIsOn = false; // 무기 상태를 추적하는 플래그

    public PlayerAttackState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        Debug.Log("공격상태진입");
        base.Enter();
        stats.StatModifier = 0f;
        StartAnimation(stateMachine.Player.AnimationData.AttackParameterHash);
        attackStartTime = Time.time;
        weaponIsOn = false;  
    }

    public override void Exit()
    {
        Debug.Log("공격상태나감");
        base.Exit();
        StopAnimation(stateMachine.Player.AnimationData.AttackParameterHash);
        stateMachine.Player.weapon.SetActive(false);  
    }

    public override void Update()
    {
        base.Update();

        Attack();

        if (stateMachine.Player.target == null)
        {
            stateMachine.ChangeState(stateMachine.WalkState);
        }
    }

    private void Attack()
    {
        if (!weaponIsOn && Time.time - attackStartTime >= Define.WARRIOR_WEAPON_ON_TIME)
        {
            stateMachine.Player.weapon.SetActive(true);
            weaponIsOn = true;
            attackStartTime = Time.time;
        }

        else if (weaponIsOn && Time.time - attackStartTime >= Define.WARRIOR_WEAPON_OFF_TIME)
        {
            stateMachine.Player.weapon.SetActive(false);
            weaponIsOn = false;
            attackStartTime = Time.time;
        }
    }
}