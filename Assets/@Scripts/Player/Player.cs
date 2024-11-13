
//플레이어에게 필요한 컴포넌트를 관리하는 클래스

using System;
using Unity.VisualScripting;
using UnityEngine;

public class Player: MonoBehaviour
{
    
    [field: SerializeField] public PlayerSO Data { get; private set;}
    public PlayerAnimationData AnimationData { get; private set;}
    public CharacterController controller;
    public Animator Animator;

    //StateMachine 관련 필드
    public GameObject weapon; //플레이어 근거리 무기 
    public GameObject target; //플레이어가 타겟 중인 적
    public Vector3 originPos; //플레이어의 기존 위치

    
    //데이터가 저장될 필요가 있는 필드
    public PlayerStatHandler statHandler;
    public Inventory Inventory { get; private set; }
    public LevelSystem LevelSystem  { get; private set; }
    private PlayerStateMachine stateMachine;

    
    
    
    private void Awake()
    {
        AnimationData = new PlayerAnimationData();
        originPos = transform.position;
    }


    public void Initialize(PlayerData playerData)
    {
        Inventory = GetComponent<Inventory>();  
        statHandler = new PlayerStatHandler(Data);
        stateMachine = new PlayerStateMachine(this, statHandler);
        LevelSystem = new LevelSystem(statHandler);
        
        if (playerData !=null)
        {
             statHandler.Stats = playerData.stats;
             LevelSystem.Level = playerData.level;
        } 
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