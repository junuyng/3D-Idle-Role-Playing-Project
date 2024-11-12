
//플레이어에게 필요한 컴포넌트를 관리하는 클래스

using System;
using Unity.VisualScripting;
using UnityEngine;

public class Player: MonoBehaviour
{
    [field: SerializeField] public PlayerSO Data { get; private set;}
    public PlayerAnimationData AnimationData { get; private set;}
    public CharacterController Controller;
    public Vector3 originPos;
    public GameObject weapon;
    public GameObject target;

    public Animator Animator;
  
    public PlayerStatHandler statHandler;
    private PlayerStateMachine stateMachine;

    private void Awake()
    {
        statHandler = new PlayerStatHandler(Data);
        stateMachine = new PlayerStateMachine(this, statHandler);
        AnimationData = new PlayerAnimationData();
        originPos = transform.position;
    }

    private void Start()
    {
        AnimationData.Initialize();
        stateMachine.ChangeState(stateMachine.IdleState);
    }

    private void Update()
    {
        stateMachine.Update();
    }

    private void FixedUpdate()
    {
        stateMachine.FixedUpdateState();
    }
    


}