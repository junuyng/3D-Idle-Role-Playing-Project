using System;
using UnityEngine;

public class CurrencyManager
{
    public int Gold { get; private set; }

    public event Action OnChangeGoldEvent;
    
    public CurrencyManager(int initialGold = 0)
    {
        Gold = initialGold;
    }
    
    
    public void ChangeGold(float amount)
    {

        int newGOLD = (int)Mathf.Max(Gold + amount , 0);
        
        
        if (newGOLD == 0)
        {
        }

        else if(newGOLD > Gold)
        {
        }
        
        else if(newGOLD < Gold)
        {
            
        }
        
        Gold = newGOLD;
        
        OnChangeGoldEvent?.Invoke();

    }


    
}