using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UIInGame : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private Button bagButton;
    [SerializeField] private RectTransform expBar;
    [SerializeField] private Button[] skillButtons;
    [SerializeField] private AudioSource buttonClickAudioSource;
    [SerializeField] private AudioClip buttonClickSound;


    private void Start()
    {
        Initialize();
        GameManager.Instance.currencyManager.OnChangeGoldEvent += ChangeGoldText;
        GameManager.Instance.Player.LevelSystem.OnLevelUpEvent += ChangeLevelText;
        GameManager.Instance.Player.LevelSystem.OnChangeExpEvent += ChangeExpBar;
    }

    private void Initialize()
    {
        InitializeButton();
        ChangeGoldText();
        ChangeExpBar(GameManager.Instance.Player.LevelSystem.CurExp /
                     GameManager.Instance.Player.LevelSystem.RequiredExp);
        ChangeLevelText();
    }


    private void InitializeButton()
    {
        bagButton.onClick.AddListener(OpenBag);
        ClickParticleSystem bagButtonParticleSystem = new ClickParticleSystem(bagButton);
        ClickSoundEffectSystem bagButtonClickSoundEffectSystem = new ClickSoundEffectSystem(bagButton,buttonClickAudioSource,buttonClickSound);

        for (int i = 0; i < skillButtons.Length; i++)
        {
            if (skillButtons[i] != null)
            {
                ClickParticleSystem skillButtonParticleSystem = new ClickParticleSystem(skillButtons[i]);
                ClickSoundEffectSystem skillButtonClickSoundEffectSystem = new ClickSoundEffectSystem(skillButtons[i],buttonClickAudioSource,buttonClickSound);
            }
        }
    }


    private void ChangeExpBar(float value)
    {
        expBar.localScale = new Vector3(value, expBar.localScale.y, expBar.localScale.z);
    }


    private void ChangeLevelText()
    {
        levelText.text = GameManager.Instance.Player.LevelSystem.Level.ToString();
    }


    private void ChangeGoldText()
    {
        goldText.text = GameManager.Instance.currencyManager.Gold.ToString();
    }


    private void OpenBag()
    {
        UIManager.Instance.GetOrCreateUI(Define.GameSceneUI.UIBag);
    }
}