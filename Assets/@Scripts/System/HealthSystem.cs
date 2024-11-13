using System;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public CreatureSO CreatureSo;

    public float MaxHP { get; private set; }
    private float currentHP;

    public event Action<float> OnDamageEvent;
    public event Action<float> OnChangeEvent;
    public event Action<GameObject> OnDeathEvent;

    private void Start()
    {
        MaxHP = CreatureSo.Data.MaxHP;
        currentHP = MaxHP;
    }


    public void ChangeHP(float amount)
    {
        float newHp = Mathf.Clamp(currentHP + amount, 0, currentHP);


        if (newHp == 0)
        {
            //TODO 클래스 분리 생각 해봐야 함
            if (gameObject.layer == LayerMask.NameToLayer("Enemy"))
                GameManager.Instance.currencyManager.ChangeGold(100);

            OnDeathEvent?.Invoke(gameObject);
            Destroy(gameObject);
        }

        else if (newHp > currentHP)
        {
        }

        else if (newHp < currentHP)
        {
            OnDamageEvent?.Invoke(amount);
        }

        currentHP = newHp;
        OnChangeEvent?.Invoke(currentHP / MaxHP);
    }
}