using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "New Item/item")]    
public class Item : ScriptableObject    //아이템 클래스 //게임오브젝트에 안붙여도 됨?
{
    public string itemName; //아이템 이름
    public ItemType itemType; //아이템 유형
    public Sprite itemImage; //아이템 이미지
    public GameObject itemPrefab; //아이템 프리팹

    public string weaponType; //무기 유형

    public enum ItemType
    {
        Equipment, // 장비
        Used,   //소모품
        Ingredient, //재료
        ETC     //기타
    }
    // Start is called before the first frame update

}
