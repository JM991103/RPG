using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// menuName : 유니티 메뉴에 표기되는 이름
// order : 메뉴에서 보일 순서
// fileName : 새로 만들면 기본으로 생성되는 이름
[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Item", order = 1)]
public class Item : ScriptableObject
{
    public string name = "Item";
    public Sprite icon = null;

}
