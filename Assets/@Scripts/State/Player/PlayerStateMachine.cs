using UnityEngine;

public class PlayerStateMachine : StateMachine
{

    public Player Player { get;}
    public PlayerStatHandler StatHandler { get; }

    public Transform MainCamTransform;

    public PlayerIdleState IdleState { get; private set; }
    public PlayerWalkState WalkState { get; private set; }
    public PlayerAttackState AttackState { get; private set; }

    public PlayerStateMachine(Player _player, PlayerStatHandler _statHandler)
    {
        Player = _player;
        StatHandler = _statHandler;

        IdleState = new PlayerIdleState(this);
        WalkState = new PlayerWalkState(this);
        AttackState = new PlayerAttackState(this);
        MainCamTransform = Camera.main.transform;
    }

}