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

    public virtual void Update()
    {
        Move();
    }

    public virtual void FixedUpdate()
    {
    }


    protected void StartAnimation(int animatorHash)
    {
        stateMachine.Player.Animator.SetBool(animatorHash, true);
    }

    protected void StopAnimation(int animatorHash)
    {
        stateMachine.Player.Animator.SetBool(animatorHash, false);
    }

    private void Move()
    {
        Vector3 moveDirection = GetMovementDirection();
        Move(moveDirection);
        Rotate(moveDirection);
    }


    private Vector3 GetMovementDirection()
    {
        return DetectTarget();
    }


    private Vector3 DetectTarget()
    {
        Collider[] colls = new Collider[Define.DETECTION_ARRAY_SIZE];
        Vector3 direction = Vector3.zero;

        
        int count = Physics.OverlapSphereNonAlloc(
            stateMachine.Player.transform.position,
            Define.ENEMY_DETECTION_RADIUS,
            colls,
            LayerMask.GetMask("Enemy")
        );

        // 적이 있다면
        if (count > 0)
        {
            float closestDistance = float.MaxValue;

            for (int i = 0; i < count; i++)
            {
                Collider coll = colls[i];
                float distance = Vector3.Distance(stateMachine.Player.transform.position, coll.transform.position);

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    direction = coll.transform.position - stateMachine.Player.transform.position;
                    direction.y = 0;
                }
            }

            return direction.normalized;
        }

        

        //현재 플레이어 x 좌표가 기존 x좌표와 다르다면 
        float dirX = stateMachine.Player.originPos.x - stateMachine.Player.transform.position.x;
        if (Mathf.Abs(dirX) > 0.05f)
        {
            direction = new Vector3(dirX, 0, 1); 
            return direction.normalized;
        }

        
        return Vector3.forward;  
    }


    private void Move(Vector3 direction)
    {
        float movementSpeed = stats.MoveSpeed * stats.StatModifier;

        stateMachine.Player.Controller.Move(direction * (movementSpeed * Time.deltaTime));
    }


    
    //TODO 회전 방식 변경 해야함 
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