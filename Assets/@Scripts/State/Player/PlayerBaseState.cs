
//모든 상태에서 공통 적인 부분을 담당하는 클래스

using UnityEngine;
using UnityEngine.UIElements;

public class PlayerBaseState : IState
{
    protected PlayerStateMachine stateMachine;
    protected PlayerStats stats;
    
    public PlayerBaseState(PlayerStateMachine _stateMachine)
    {
        stateMachine = _stateMachine;
        stats = _stateMachine.StatHandler.Stats;
    }

    public virtual void Enter()
    {
        
    }

    public virtual void Exit()
    {
        
    }

    public  virtual void Update()
    {
        Move();
    }

    public virtual void FixedUpdate()
    {
        
    }


    protected void StartAnimation(int animatorHash)
    {
        stateMachine.Player.Animator.SetBool(animatorHash,true);
    }

    protected void StopAnimation(int animatorHash)
    {
        stateMachine.Player.Animator.SetBool(animatorHash,false);
    }

    private void Move()
    {
        Vector3 moveDirection = GetMovementDirection();
        Move(moveDirection);
        Rotate(moveDirection);
    }

    private Vector3 GetMovementDirection()
    {
        //가장 가까운 적 위치 탐색 
        
        // 거리 계산해서 방향 리턴 (정규화 중요)
        return Vector3.forward;
    }

    private void Move(Vector3 direction)
    {
        float movementSpeed = stats.MoveSpeed * stats.StatModifier;
        stateMachine.Player.Controller.Move((direction * movementSpeed) * Time.deltaTime);
    }

    private void Rotate(Vector3 direction)
    {
        if (direction != Vector3.zero)
        {
            Transform playerTransform = stateMachine.Player.transform;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            playerTransform.rotation = Quaternion.Slerp(playerTransform.rotation, targetRotation,
                stats.RotationSpeed * Time.deltaTime);
        }
    }



}