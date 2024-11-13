using System.Collections;
using UnityEngine;
using DG.Tweening;
public interface IShowStrategy
{
    void Execute();
}


public class ShowNoneStrategy : IShowStrategy
{
    private GameObject go;

    public ShowNoneStrategy(GameObject _go)
    {
        go = _go;
    }


    public void Execute()
    {
        go.SetActive(true);
     }
    
}

public class ShowPopUpStrategy : IShowStrategy
{
    private GameObject go;

    public ShowPopUpStrategy(GameObject _go)
    {
        go = _go;
    }


    public void Execute()
    {
        go.transform.localScale = Vector3.zero;
        go.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);
    }
    
}