//모든 상태에서 공통 적인 부분을 담당하는 클래스

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
  

}