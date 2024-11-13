using System.Collections.Generic;
using UnityEngine;


public class UIManager : Singleton<UIManager>
{
    
    private List<GameObject> existingUIList = new List<GameObject>();

    
    //TODO 씬에 따라서 UI가 겹치는 경우 방지 해줘야 함.
    public GameObject GetOrCreateUI(Define.GameSceneUI gameSceneUI)
    {
        foreach (var existingUI in existingUIList)
        {
            if (existingUI.name == gameSceneUI.ToString())
            {
                existingUI.SetActive(true);
                return existingUI;
            }

        }

        GameObject uiPrefab = Resources.Load<GameObject>($"UI/{gameSceneUI}");
        GameObject newExistingUI = Instantiate(uiPrefab);
        newExistingUI.name = Utils.RemoveCloneFormat(newExistingUI.name);
        existingUIList.Add(newExistingUI);
        return newExistingUI;
    }
}