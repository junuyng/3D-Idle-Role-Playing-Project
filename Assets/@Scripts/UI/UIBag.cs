using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBag : MonoBehaviour
{
    [SerializeField] private Button[] TabButtons;
    [SerializeField] private Transform ScrollViewContentPos;

    private GameObject content;
    private List<GameObject> itemSlots = new List<GameObject>();

    private void Awake()
    {
        for (int i = 0; i < TabButtons.Length; i++)
        {
            int index = i;
            TabButtons[i].onClick.AddListener(() => UpdateBagContent(index));
        }
        
        content = Resources.Load<GameObject>("UI/UIBagItemSlot");
    }

    private void Start()
    {
        UpdateBagContent(0);
    }

    private void UpdateBagContent(int index)
    {
        ClearItemSlots();


        Define.ItemType type = (Define.ItemType)index;

        if (!GameManager.Instance.Player.Inventory.Items.ContainsKey(type))
        {
            Debug.LogWarning($"ItemType {type} not found in the inventory.");
            return;
        }

        List<Item> items = GameManager.Instance.Player.Inventory.Items[type];

        foreach (var item in items)
        {
            GameObject newItemSlot = Instantiate(content, ScrollViewContentPos);
            newItemSlot.GetComponent<UIBagItemSlot>().Initialize(item);
            itemSlots.Add(newItemSlot);
        }
    }


    private void ClearItemSlots()
    {
        if(itemSlots.Count == 0)
            return;
        
        foreach (var slot in itemSlots)
        {
            Destroy(slot);
        }

        itemSlots.Clear();
    }
}