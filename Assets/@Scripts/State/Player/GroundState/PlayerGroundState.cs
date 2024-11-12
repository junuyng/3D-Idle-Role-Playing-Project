
    public class PlayerGroundState : PlayerBaseState
    {
        public PlayerGroundState(PlayerStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            base.Enter();
            StartAnimation(stateMachine.Player.AnimationData.GroundParameterHash);
        }

        
        public override void Exit()
        {
            base.Exit();
            StopAnimation(stateMachine.Player.AnimationData.GroundParameterHash);
        }

        public override void Update()
        {
            base.Update();
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
        }


    }
