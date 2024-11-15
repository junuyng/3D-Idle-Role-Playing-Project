using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UIBagItemSlot : MonoBehaviour
{
    private Item _item;

    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI stats;
    [SerializeField] private TextMeshProUGUI level;
    [SerializeField] private TextMeshProUGUI equipStatusText;

    [SerializeField] private Button enchantButton;
    [SerializeField] private Button equipButton;


    private void Awake()
    {
        equipButton.onClick.AddListener(EquipOrUnEquip);
        enchantButton.onClick.AddListener(Enchant);
    }

    public void Initialize(Item item)
    {
        _item = item;
        Debug.Log("아이템레벨" + _item.level);
        UpdateUI();
    }

    private void UpdateUI()
    {
        icon.sprite = _item.data.icon;
        itemName.text = _item.data.itemName;
        stats.text = $"{_item.data.stat * _item.level}";
        level.text = _item.level.ToString();
    }


    private void Enchant()
    {
        int enchantCost = Define.ENCHANT_BASE_COST * _item.level;

        if (enchantCost >  GameManager.Instance.currencyManager.Gold)
        {
            Debug.Log("강화 비용이 부족합니다.");
            return;
        }

        GameManager.Instance.currencyManager.ChangeGold(-enchantCost);

        // 장비 능력치 초기화 및 재부여
        if (_item.isEquipped)
        {
            GameManager.Instance.Player.statHandler.AdjustStatsForEquipment(_item, false);
        }

        _item.level++;

        if (_item.isEquipped)
        {
            GameManager.Instance.Player.statHandler.AdjustStatsForEquipment(_item, true);
        }

        UpdateUI();
    }


    //TODO 다른 장비 착용할 시 UI 상에서 UnEquip / Equip 변경하기 ! 
    private void EquipOrUnEquip()
    {
        if (!_item.isEquipped)
        {
            GameManager.Instance.Player.Inventory.EquipItem(_item);
            equipStatusText.text = "UnEquip";
        }

        else
        {
            GameManager.Instance.Player.Inventory.UnEquipItem();
            equipStatusText.text = "Equip";
        }

        _item.isEquipped = !_item.isEquipped; // isEquipped 값 반전
    }
}