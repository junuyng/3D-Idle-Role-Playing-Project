using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "ItemData")]
public class ItemDataSO : ScriptableObject
{
    public Define.ItemType type;
    public Sprite icon;
    public string itemName;
    public float stat; // 각 타입은 하나의 스탯만 갖을 수 있음. 
}