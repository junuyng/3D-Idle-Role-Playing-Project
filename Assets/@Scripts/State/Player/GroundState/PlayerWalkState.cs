using UnityEngine;

public class PlayerWalkState : PlayerGroundState
{
    public PlayerWalkState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
         stats.StatModifier = 1f;
        StartAnimation(stateMachine.Player.AnimationData.WalkParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Player.AnimationData.WalkParameterHash);
    }

    public override void Update()
    {
        base.Update();
        Move();
        if (CanAttack())
            stateMachine.ChangeState(stateMachine.AttackState);
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


        // 적이 있고 target이 설정되지 않았다면
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
                    stateMachine.Player.target = coll.gameObject;
                    direction = coll.transform.position - stateMachine.Player.transform.position;
                    direction.y = 0;
                }
            }

            return direction.normalized;
        }
        
        
        //TODO 플레이어가 이동한 X가 기존 플레이어의 X축과 크게 차이나지 않으면 급격한 회전
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

        stateMachine.Player.controller.Move(direction * (movementSpeed * Time.deltaTime));
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


    private bool CanAttack()
    {
        Collider[] colls = new Collider[Define.DETECTION_ARRAY_SIZE];
        Vector3 direction = Vector3.zero;

        int count = Physics.OverlapSphereNonAlloc(
            stateMachine.Player.transform.position,
            Define.ATTACK_RANGE,
            colls,
            LayerMask.GetMask("Enemy")
        );

        if (count > 0)
        {
            return true;
        }

        return false;
    }
}