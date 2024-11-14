using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UILobby : MonoBehaviour
{

    [SerializeField] private Button [] stageButtons;

    private void Awake()
    {
        InitializeStageButtons();
    }


    //GameManger 레벨을 가져와서 초기화 
    private void InitializeStageButtons()
    {
        for (int i = 0; i < stageButtons.Length; i++)
        {
            int index = i;
            stageButtons[i].interactable = GameManager.Instance.MaxStageLevel >= i;
            
            if(stageButtons[i].interactable)
                stageButtons[i].onClick.AddListener(()=>LoadStage(index));
        }
    }

    
    
    
    private void LoadStage(int index)
    {
        GameManager.Instance.CurrentStage = index;
        SceneManager.LoadScene(Define.SceneType.GameScene.ToString());
    }
    
    
    


}
