using System;
using UnityEngine;


public class UIView : MonoBehaviour
{
    private Define.UIAppearance UIAppearance;
    private IShowStrategy ShowStrategy;
    private IHideStrategy HideStrategy;


    //PopUp 방식 말고는 따로 사용하지 않아서 이렇게 처리
    //TODO 다양한 방식에 적용할 수 있도록 Factory Pattern등 고민 
    private void OnEnable()
    {
        ShowStrategy = new ShowPopUpStrategy(this.gameObject);
        HideStrategy = new HidePopUpStrategy(this.gameObject);
        Show();
    }

    
 
    public void Show()
    {
        ShowStrategy.Execute();
    }

    public void Hide()
    {
        HideStrategy.Execute();
    }
 

}