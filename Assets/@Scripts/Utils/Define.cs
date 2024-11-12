using UnityEngine;

public class Define
{
    // 감지 및 전투 상수
    public const float ENEMY_DETECTION_RADIUS = 100f; // 적 감지 반경
    public const float ATTACK_RANGE = 1f;             // 공격 가능 거리
    public const int DETECTION_ARRAY_SIZE = 10;       // 감지 배열 크기

    // 전사 무기 활성화 타이밍 상수
    public const float WARRIOR_WEAPON_ON_TIME = 0.1f; // 무기 활성화 시간
    public const float WARRIOR_WEAPON_OFF_TIME = 0.15f; // 무기 비활성화 시간
}