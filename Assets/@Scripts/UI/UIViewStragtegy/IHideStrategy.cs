using System.Collections;
using DG.Tweening;
using UnityEngine;

//ui가 존재하는지 안 하는지를 판단해주고 없으면 생성 

public interface IHideStrategy
{
     void Execute();
}

public class HideNoneStrategy : IHideStrategy
{
     private GameObject go;

     public HideNoneStrategy(GameObject _go)
     {
          go = _go;
     }


     public void Execute()
     {
          go.SetActive(true);
     }
    
}

public class HidePopUpStrategy : IHideStrategy
{
     private GameObject go;

     public HidePopUpStrategy(GameObject _go)
     {
          go = _go;
     }


     //DOTween 콜백 메서드 활용
     public void Execute()
     {
          go.transform.DOScale(Vector3.zero, 0.5f)
               .SetEase(Ease.OutBack)
               .OnComplete(() => go.transform.parent.gameObject.SetActive(false));
     }
}