using UnityEngine;

public class PlayerAttackState : PlayerGroundState
{
    //TODO Player 직업에 따라 상수 가져와 설정 하도록 
    
    private float lastActivationTime = 0f; // 마지막 활성화 시점 기록
         

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
            //TODO 몬스터 정보 불러와서 수정 
            GameManager.Instance.Player.LevelSystem.AddExp(100);
        }
    }



    //TODO 피격 타임 정상화 시키기
    private void Attack()
    {
        float activationInterval = 0.13f; 

        if (Time.time >= lastActivationTime + activationInterval)
        {
            stateMachine.Player.weapon.SetActive(true);
            weaponIsOn = true;
            lastActivationTime = Time.time; // 마지막 활성화 시간 갱신
        }
    }


}