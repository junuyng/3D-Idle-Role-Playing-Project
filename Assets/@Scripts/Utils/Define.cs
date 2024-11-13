using UnityEngine;

public class Define
{
    
    public enum DataType
    {
        GameManager,
        Player,
        
    }
    
    public enum  ItemType
    {
        Weapon,
        Armor,
        Potion
    }
    
    public enum  SceneType
    {
        Lobby,
        Game
    }

    public enum  GameSceneUI
    {
        UIBag,
        UIBagItemSlot
    }
    
    public enum UIAppearance
    {
        None,
        PopUp,
        FadeIn,
        SlideIn,
        SlideFadeIn
    }
    public enum UIHideAppearance
    {
        None,
        PopUp,
        FadeIn,
        SlideIn,
        SlideFadeIn
    }
    public enum EnemyType
    {
        Goblin,
        Skeleton
    }
    
    // 감지 및 전투 상수
    public const float ENEMY_DETECTION_RADIUS = 100f; // 적 감지 반경
    public const float ATTACK_RANGE = 1f;             // 공격 가능 거리
    public const int DETECTION_ARRAY_SIZE = 10;       // 감지 배열 크기

    // 전사 무기 활성화 타이밍 상수
    public const float WARRIOR_WEAPON_ON_TIME = 0.1f; // 무기 활성화 시간
    public const float WARRIOR_WEAPON_OFF_TIME = 0.5f; // 무기 비활성화 시간
    
    // 강화 관련 상수
    public const int ENCHANT_BASE_COST = 100; //최초 강화 비용
    
    //경험치 관련 상수
    public const int EXP_BASE_GAIN = 100; //최초 강화 비용
    
    // 기타 상수
    public const float FADE_INTERVAL = 0.1f; // 텍스트 페이드 간격

    //스탯 증가 비율 관련 상수
    public const float ATTACK_POWER_INCREASE_RATE = 1.5f; // 공격력 증가 비율
    public const float DEFENSE_POWER_INCREASE_RATE = 1.2f; // 방어력 증가 비율
    public const float CRITICAL_DAMAGE_INCREASE_RATE = 0.5f; // 치명타 피해 증가 비율
    public const float CRITICAL_CHANCE_INCREASE_RATE = 0.1f; // 치명타 확률 증가 비율

    //기본 적 생성 수 
    public const int DefaultEnemySpawnCount = 5;

}