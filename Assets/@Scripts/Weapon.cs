using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


//TODO 공격 데미지 전달 방식 변경 할 것 
public class Weapon : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            other.GetComponent<HealthSystem>().ChangeHP(-GameManager.Instance.Player.statHandler.GetDamage());
            gameObject.SetActive(false);
        }
    }
}