using System;
using UnityEngine;


[Serializable]
public  class Item  {
    
   public ItemDataSO data;
   
   public int level = 1;
   public bool isEquipped = false;
   
    public Item(ItemDataSO _data)
    {
        data = _data;
    }
    
}