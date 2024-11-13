using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    
    public Dictionary<Define.ItemType, List<Item>> Items = new Dictionary<Define.ItemType, List<Item>>();
    
    
    [SerializeField]private List<Item> weaponItems = new List<Item>();
    [SerializeField]private List<Item> armorItems = new List<Item>();
    [SerializeField]private List<Item> potionItems = new List<Item>();


    private Item equippedItem = null;

    private void Awake()
    {
        if(Items.Count ==0)
            InitItemDictionary();
    }


    public void EquipItem(Item item)
    {
        if (item == null)
        {
            return;
        }

        if (equippedItem != null)
            UnEquipItem();

        equippedItem = item;
        GameManager.Instance.Player.statHandler?.AdjustStatsForEquipment(equippedItem, true);
    }

    
    public void UnEquipItem()
    {
        if (equippedItem == null)
        {
            return;
        }
        
        GameManager.Instance.Player.statHandler?.AdjustStatsForEquipment(equippedItem, false);
        equippedItem = null;
    }
    
    
    
    
    private void AddItem(ItemDataSO data)
    {
        AddItemToListByType(data);
    }

    

    public void AddItemToListByType(ItemDataSO data)
    {
        switch (data.type)
        {  
            case Define.ItemType.Weapon: 
                 weaponItems.Add(new Item(data));
                 Debug.Log("아이템 생성시 레벨"+weaponItems[0].level);
                break;
            case Define.ItemType.Armor: 
                 weaponItems.Add(new Item(data));
                break;
            case Define.ItemType.Potion: 
                 weaponItems.Add(new Item(data));
                break;
         }
        
    }

    private void InitItemDictionary()
    {
        Items.Add(Define.ItemType.Weapon, weaponItems);
        Items.Add(Define.ItemType.Armor, armorItems);
        Items.Add(Define.ItemType.Potion, potionItems);
    }
}