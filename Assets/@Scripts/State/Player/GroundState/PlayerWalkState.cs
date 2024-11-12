
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
        
        
        
    }
