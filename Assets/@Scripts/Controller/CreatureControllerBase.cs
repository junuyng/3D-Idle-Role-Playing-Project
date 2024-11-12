using System;
using UnityEngine;
using UnityEngine.Serialization;

//크리쳐 들의 공통점을 모아 놓은 클래스 
public class CreatureControllerBase : MonoBehaviour
{
    protected float currentHP;
    protected CreatureSO stats;
    protected Animator animator;
    
    protected virtual void Start()
    {
    }
    
}




