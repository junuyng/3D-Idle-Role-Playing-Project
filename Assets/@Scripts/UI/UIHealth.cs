using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIHealth : MonoBehaviour
{
    [SerializeField] private RectTransform hpBar;
    [SerializeField] private Transform damageParticlePos;
    [SerializeField] private GameObject damageParticle;


    private HealthSystem healthSystem;

    private void Awake()
    {
        healthSystem = GetComponentInParent<HealthSystem>();
    }

    private void Start()
    {
        healthSystem.OnChangeEvent += UpdateHpBar;
        healthSystem.OnDamageEvent += InstantiateDamageParticle;
    }


    private void UpdateHpBar(float value)
    {
        hpBar.localScale = new Vector3(value, hpBar.localScale.y, hpBar.localScale.z);
    }


    private void InstantiateDamageParticle(float damage)
    {
        GameObject newDamageParticle = Instantiate(damageParticle, damageParticlePos.transform);

        TextMeshProUGUI damageText = newDamageParticle.GetComponent<TextMeshProUGUI>();
        damageText.text = Mathf.Abs(damage).ToString();
    }
}